
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Commands;
using KanbanBoard.Models;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using KanbanBoard.Views.ChildWindows;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
namespace KanbanBoard.ViewModel
{
    public class BoardsListViewModel : BaseViewModel
    {
        //TODO : Add implementation
        private readonly IUnityContainer container;
        private readonly InteractionRequest<Confirmation> confirmDelete;

        public DelegateCommand AddNewBoard { get; set; }
        public DelegateCommand RemoveBoard { get; private set; }
        public DelegateCommand EditBoard { get; private set; }
        public DelegateCommand SelectBoard { get; private set; }

        public InteractionRequest<Confirmation> ConfirmDelete
        {
            get { return confirmDelete; }
        }

        public ObservableCollection<UserBoard> BoardsList { get; set; }

        public BoardsListViewModel(IUnityContainer container)
            : base()
        {
            this.container = container;
            confirmDelete = new InteractionRequest<Confirmation>();

            BoardsList = new ObservableCollection<UserBoard>();
            BoardsList.Add(new UserBoard { BoardID = 1, BoardName = "testName1" });
            BoardsList.Add(new UserBoard { BoardID = 2, BoardName = "testName2" });
            BoardsList.Add(new UserBoard { BoardID = 3, BoardName = "testName3" });

            RemoveBoard = new DelegateCommand(() =>
            {
                // ToDo : Add some logic for removing boards 
                bool isUserConfirmed = false;
                confirmDelete.Raise(new Confirmation()
                {
                    Content = "Are you sure you want to remove this record?",
                    Title = "Confirm remove",
                }, confirmation => 
                {
                    if (confirmation.Confirmed)
                    {
                        BoardsList.RemoveAt(0);
                        NotifyPropertyChanged("BoardsList");
                    }
                });
            });

            AddNewBoard = new DelegateCommand(() =>
            {
                var boardView = this.container.Resolve<BoardChildWindow>();
                boardView.Title = "Add new board";
                boardView.Show();
            });

            EditBoard = new DelegateCommand(() =>
            {
                // ToDo : Add parametr for the child window. Or make child window as confirmation dialog for delete operation
                var boardView = this.container.Resolve<BoardChildWindow>();
                boardView.Title = "Edit board";
                boardView.Show();
            });
        }
    }
}