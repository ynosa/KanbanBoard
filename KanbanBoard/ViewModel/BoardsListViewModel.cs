
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
        private readonly IUnityContainer container;
        private readonly InteractionRequest<Confirmation> confirmDelete;
        private readonly InteractionRequest<Confirmation> boardDialog;

        public DelegateCommand AddNewBoard { get; set; }
        public DelegateCommand RemoveBoard { get; private set; }
        public DelegateCommand EditBoard { get; private set; }
        public DelegateCommand SelectBoard { get; private set; }

        public InteractionRequest<Confirmation> ConfirmDelete
        {
            get { return confirmDelete; }
        }
        public InteractionRequest<Confirmation> BoardDialog
        {
            get { return boardDialog; }
        }

        public ObservableCollection<UserBoard> BoardsList { get; set; }

        public BoardsListViewModel(IUnityContainer container)
            : base()
        {
            this.container = container;
            
            confirmDelete = new InteractionRequest<Confirmation>();
            boardDialog = new InteractionRequest<Confirmation>();
            BoardsList = new ObservableCollection<UserBoard>();

            BoardsList.Add(new UserBoard { BoardID = 1, BoardName = "testName1" });
            BoardsList.Add(new UserBoard { BoardID = 2, BoardName = "testName2" });
            BoardsList.Add(new UserBoard { BoardID = 3, BoardName = "testName3" });

            RemoveBoard = new DelegateCommand(() =>
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
                        //BoardsList.RemoveAt(0);
                        //NotifyPropertyChanged("BoardsList");
                    }
                });
            });

            AddNewBoard = new DelegateCommand(() =>
            {
                // ToDo : Continue implementation and don't forget about parametr for the child window.
                boardDialog.Raise(new Confirmation()
                    {
                        Title = "Add new board"
                    },
                    confirmation =>
                    {
                        
                    });
            });

            EditBoard = new DelegateCommand(() =>
            {
                // ToDo : Implement and don't forget about parametr for the child window.
            });
        }
    }
}