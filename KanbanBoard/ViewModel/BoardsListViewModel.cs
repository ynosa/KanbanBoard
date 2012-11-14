
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Commands;
using KanbanBoard.Models;
using Microsoft.Practices.Prism.Regions;
using KanbanBoard.Web;
using System.ServiceModel.DomainServices.Client;
namespace KanbanBoard.ViewModel
{
    public class BoardsListViewModel : BaseViewModel
    {
        public DelegateCommand AddNewBoard { get; set; }
        public DelegateCommand RemoveBoard { get; private set; }
        public DelegateCommand EditBoard { get; private set; }
        public DelegateCommand SelectBoard { get; private set; }
        private KanbanBoardDomainContext kanbanBoardDomainContext = new KanbanBoardDomainContext();    

        public EntitySet<Board> BoardsList
        {
            get
            {
                return kanbanBoardDomainContext.Boards;
            }
        }

        public BoardsListViewModel()
            : base()
        {
            kanbanBoardDomainContext.Load(kanbanBoardDomainContext.GetBoardsQuery());

            RemoveBoard = new DelegateCommand(() =>
            {
                //BoardsList.
                //BoardsList.RemoveAt(0); 
                NotifyPropertyChanged("BoardsList");
            });
        }
    }
}