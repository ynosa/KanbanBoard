
using KanbanBoard.Helpers;
using KanbanBoard.Views.ChildWindows;
using KanbanBoard.Web;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.ServiceModel.DomainServices.Client;
namespace KanbanBoard.ViewModel
{
    public class BoardsListViewModel : BaseViewModel
    {
        private const string BOARD_VIEW = "BoardView";
        private const string BOARD_PARAMS_TEMPLATE = "BOARD_ID:{0}";


        private readonly IUnityContainer container;
        private readonly InteractionRequest<Confirmation> confirmDelete;
        private readonly InteractionRequest<Confirmation> boardDialog;
        private readonly ViewOrchestrator viewOrchestrator;

        public DelegateCommand AddBoardCommand { get; set; }
        public DelegateCommand<Board> RemoveBoardCommand { get; private set; }
        public DelegateCommand EditBoardCommand { get; private set; }
        public DelegateCommand SelectBoardCommand { get; private set; }
        private KanbanBoardDomainContext kanbanBoardDomainContext = new KanbanBoardDomainContext();

        public InteractionRequest<Confirmation> ConfirmDelete
        {
            get { return confirmDelete; }
        }
        public InteractionRequest<Confirmation> BoardDialog
        {
            get { return boardDialog; }
        }

        public EntitySet<Board> BoardsList
        {
            get
            {
                return kanbanBoardDomainContext.Boards;
            }
        }

        public BoardsListViewModel(IUnityContainer container, ViewOrchestrator viewOrchestrator)
            : base()
        {
            this.container = container;
            this.viewOrchestrator = viewOrchestrator;

            confirmDelete = new InteractionRequest<Confirmation>();
            boardDialog = new InteractionRequest<Confirmation>();

            kanbanBoardDomainContext.Load(kanbanBoardDomainContext.GetBoardsQuery());

            AddBoardCommand = new DelegateCommand(() => AddBoard());

            EditBoardCommand = new DelegateCommand(() => EditBoard());

            RemoveBoardCommand = new DelegateCommand<Board>((board) => RemoveBoard(board));

            SelectBoardCommand = new DelegateCommand(() => SelectBoard());

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

                    kanbanBoardDomainContext.Boards.Add(new Board() { BoardName = dialog.BoardName, UserName = string.Empty, Id = System.Guid.Empty });
                    kanbanBoardDomainContext.SubmitChanges();
                }
            };
            dialog.Show();
        }

        private void EditBoard()
        {
            // ToDo : Add implementation
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

        private void SelectBoard()
        {
            viewOrchestrator.ChangeView(RegionNames.MAIN_REGION, BOARD_VIEW, string.Format(BOARD_PARAMS_TEMPLATE, 1));
        }
    }
}