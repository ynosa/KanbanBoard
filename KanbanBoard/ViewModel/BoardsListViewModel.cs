
using KanbanBoard.Events;
using KanbanBoard.Views.ChildWindows;
using KanbanBoard.Web;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Unity;
using System;
using System.ServiceModel.DomainServices.Client;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System.Text;
namespace KanbanBoard.ViewModel
{
    public class BoardsListViewModel : BaseViewModel
    {
        private readonly IUnityContainer container;
        private readonly InteractionRequest<Confirmation> confirmDelete;

        public DelegateCommand AddBoardCommand { get; set; }
        public DelegateCommand<Board> RemoveBoardCommand { get; private set; }
        public DelegateCommand<Board> EditBoardCommand { get; private set; }
        public DelegateCommand SelectBoardCommand { get; private set; }
        public DelegateCommand<Board> ManageBoardCommand { get; private set; }
        private KanbanBoardDomainContext kanbanBoardDomainContext = new KanbanBoardDomainContext();

        private IEventAggregator eventAggregator;

        public InteractionRequest<Confirmation> ConfirmDelete
        {
            get { return confirmDelete; }
        }

        public EntitySet<Board> BoardsList
        {
            get
            {
                return kanbanBoardDomainContext.Boards;
            }
        }

        public BoardsListViewModel(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this.container = container;
            this.eventAggregator = eventAggregator;

            confirmDelete = new InteractionRequest<Confirmation>();

            kanbanBoardDomainContext.Load(kanbanBoardDomainContext.GetBoardsQuery());

            AddBoardCommand = new DelegateCommand(this.AddBoard);
            EditBoardCommand = new DelegateCommand<Board>(this.EditBoard);
            RemoveBoardCommand = new DelegateCommand<Board>(this.RemoveBoard);
            ManageBoardCommand = new DelegateCommand<Board>(this.ManageBoard);
        }

        private void AddBoard()
        {
            var dialog = this.container.Resolve<BoardChildWindow>();

            dialog.Title = "Add new board"; // Don't forget about title!
            dialog.Closed += (s, e) =>
            {
                if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                {
                    // ToDo : Add implementation when board title isn't empty.
                    // Board name get from dialog.BoardName property!
                    Board board = new Board() { BoardName = dialog.BoardName, UserName = WebContextBase.Current.Authentication.User.Identity.Name, Id = Guid.NewGuid() };

                    //BoardColumn bc = new BoardColumn() { Board = board, Name = "bc", Position = 0, Id=Guid.NewGuid() };
                    //Task tk = new Task() { BoardColumn = bc, Description = "Descr", Name = "nm", Position = 0, Id = Guid.NewGuid() };
                    //bc.Tasks.Add(tk);
                    //board.BoardColumns.Add(bc);

                    if (HasValidationErrors(board))
                    {
                        dialog.Show();
                        return;
                    }


                    kanbanBoardDomainContext.Boards.Add(board);
                    kanbanBoardDomainContext.SubmitChanges();
                }
            };
            dialog.Show();
        }

        private static bool HasValidationErrors(Board board)
        {
            if (board.HasValidationErrors)
            {
                StringBuilder builder = new StringBuilder();

                foreach (var error in board.ValidationErrors)
                {
                    if (builder.Length > 0)
                        builder.AppendLine();

                    builder.Append(error.ErrorMessage);
                }

                builder.Insert(0, "There are some validation error(s). Please fix error(s) to proceed: \r\n\r\n");

                System.Windows.MessageBox.Show(builder.ToString(), "Validation errors", System.Windows.MessageBoxButton.OK);
            }

            return board.HasValidationErrors;
        }

        private void EditBoard(Board board)
        {
            var dialog = this.container.Resolve<BoardChildWindow>();

            dialog.Title = "Edit board"; // Don't forget about title!
            dialog.BoardName = board.BoardName;
            dialog.Closed += (s, e) =>
            {
                if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                {
                    board.BoardName = dialog.BoardName;

                    if (HasValidationErrors(board))
                    {
                        dialog.Show();
                        return;
                    }

                    kanbanBoardDomainContext.SubmitChanges();
                    NotifyPropertyChanged("BoardsList");
                }
            };
            dialog.Show();
        }

        private void ManageBoard(Board board)
        {
            this.eventAggregator.GetEvent<BoardSelectedEvent>().Publish(board);
        }

        private void RemoveBoard(Board board)
        {
            confirmDelete.Raise(new Confirmation()
            {
                Content = "Are you sure you want to remove this record?",
                Title = "Confirm remove",
            }, confirmation =>
            {
                if (confirmation.Confirmed)
                {
                    kanbanBoardDomainContext.Boards.Remove(board);
                    kanbanBoardDomainContext.SubmitChanges();
                    NotifyPropertyChanged("BoardsList");
                }
            });

        }

    }
}