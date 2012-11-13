
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Commands;
using KanbanBoard.Models;
using Microsoft.Practices.Prism.Regions;
namespace KanbanBoard.ViewModel
{
    public class BoardsListViewModel : BaseViewModel
    {
        //TODO : Add implementation

        public DelegateCommand AddNewBoard { get; set; }
        public DelegateCommand RemoveBoard { get; private set; }
        public DelegateCommand EditBoard { get; private set; }
        public DelegateCommand SelectBoard { get; private set; }

        public ObservableCollection<UserBoard> BoardsList { get; set; }

        public BoardsListViewModel()
            : base()
        {
            BoardsList = new ObservableCollection<UserBoard>();
            BoardsList.Add(new UserBoard { BoardID = 1, BoardName = "testName1" });
            BoardsList.Add(new UserBoard { BoardID = 2, BoardName = "testName2" });
            BoardsList.Add(new UserBoard { BoardID = 3, BoardName = "testName3" });

            RemoveBoard = new DelegateCommand(() =>
            {
                BoardsList.RemoveAt(0); 
                NotifyPropertyChanged("BoardsList");
            });
        }
    }
}