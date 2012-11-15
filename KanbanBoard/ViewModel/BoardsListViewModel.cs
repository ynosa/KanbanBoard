
using KanbanBoard.Views.ChildWindows;
using KanbanBoard.Web;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Unity;
using System.ServiceModel.DomainServices.Client;
namespace KanbanBoard.ViewModel
{
    public class BoardsListViewModel : BaseViewModel
    {
        private readonly IUnityContainer container;
        private readonly InteractionRequest<Confirmation> confirmDelete;
        private readonly InteractionRequest<Confirmation> boardDialog;
        private string boardTitle = "title";

        public DelegateCommand AddBoardCommand { get; set; }
        public DelegateCommand RemoveBoardCommand { get; private set; }
        public DelegateCommand EditBoardCommand { get; private set; }
        public DelegateCommand SelectBoardCommand { get; private set; }
        public string BoardTitle
        {
            get { return boardTitle; }
            set
            {
                boardTitle = value;
                NotifyPropertyChanged("BoardTitle");
            }
        }
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

        public BoardsListViewModel(IUnityContainer container)
            : base()
        {
            this.container = container;

            confirmDelete = new InteractionRequest<Confirmation>();
            boardDialog = new InteractionRequest<Confirmation>();

            kanbanBoardDomainContext.Load(kanbanBoardDomainContext.GetBoardsQuery());

            AddBoardCommand = new DelegateCommand(() => AddBoard());

            EditBoardCommand = new DelegateCommand(() => EditBoard());

            RemoveBoardCommand = new DelegateCommand(() => RemoveBoard());

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
                }
            };
            dialog.Show();
        }

        private void EditBoard()
        {
            // ToDo : Add implementation
        }

        private void RemoveBoard()
        {
            confirmDelete.Raise(new Confirmation()
            {
                Content = "Are you sure you want to remove this record?",
                Title = "Confirm remove",
            }, confirmation =>
            {
                if (confirmation.Confirmed)
                {
                    // ToDo : Add implementation for removig the board from the list.
                }
            });
            NotifyPropertyChanged("BoardsList");
        }

    }
}