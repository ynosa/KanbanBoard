
using KanbanBoard.Web;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;

namespace KanbanBoard.ViewModel
{
    public class BoardViewModel : BaseViewModel, INavigationAware
    {
        public DelegateCommand AddNewColumnCommand { get; set; }
        public DelegateCommand RemoveColumnCommand { get; set; }

        public DelegateCommand AddNewTaskCommand { get; set; }
        public DelegateCommand RemoveTaskCommand { get; set; }

        public static string BoardIdParam = "BoardId";

        private Guid BoardId;

        public ObservableCollection<BoardColumn> BoardColumns { get; set; }

        private readonly KanbanBoardDomainContext kanbanBoardDomainContext = new KanbanBoardDomainContext();

        public BoardViewModel()
            : base()
        {
            AddNewColumnCommand = new DelegateCommand(AddNewColumn);
            RemoveColumnCommand = new DelegateCommand(RemoveColumn);

            AddNewTaskCommand = new DelegateCommand(AddNewTask);
            RemoveTaskCommand = new DelegateCommand(RemoveTask);
        }

        private void AddNewColumn()
        {
            throw new NotImplementedException();
        }

        private void RemoveColumn()
        {
            throw new NotImplementedException();
        }

        private void AddNewTask()
        {
            throw new NotImplementedException();
        }

        private void RemoveTask()
        {
            throw new NotImplementedException();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            BoardId = Guid.Parse(navigationContext.Parameters[BoardIdParam]);
            this.ProcessBoardItems();
        }

        public void ProcessBoardItems()
        {
            kanbanBoardDomainContext.Load(kanbanBoardDomainContext.GetBoardColumnsQuery().Where(obj => obj.BoardId == this.BoardId), this.OnProcessed, null);
        }

        public virtual void OnProcessed(LoadOperation<BoardColumn> operation)
        {
            this.BoardColumns = new ObservableCollection<BoardColumn>(operation.Entities);
            NotifyPropertyChanged("BoardColumns");
        }

    }
}