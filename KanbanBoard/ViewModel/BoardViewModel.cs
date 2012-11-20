
using KanbanBoard.Web;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;

namespace KanbanBoard.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceModel.DomainServices.Client;

        public DelegateCommand AddNewTaskCommand { get; set; }
        public DelegateCommand RemoveTaskCommand { get; set; }

        public static string BoardIdParam = "BoardId";

        private Guid BoardId;

        private ObservableCollection<BoardColumn> _boardsColumns;

        public ObservableCollection<BoardColumn> BoardsColumns
        {
            get
            {
                return this._boardsColumns;
            }
            set
            {
                this._boardsColumns = value;
                this.NotifyPropertyChanged("BoardsColumns");
            }
        }

        private KanbanBoardDomainContext kanbanBoardDomainContext = new KanbanBoardDomainContext();

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
             this._boardsColumns=new ObservableCollection<BoardColumn>(operation.Entities.OrderBy(obj=>obj.Position));
             this._boardsColumns.CollectionChanged += this.BoardColumnsCollectionChanged;             
        }

        void BoardColumnsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {            
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        foreach (var columnItem in e.NewItems.OfType<BoardColumn>())
                        {
                            columnItem.BoardId = BoardId;
                            kanbanBoardDomainContext.BoardColumns.Add(columnItem);
                        }
                        break;
                    }
                    

                case NotifyCollectionChangedAction.Remove:
                    {
                        foreach (var columnItem in e.OldItems.OfType<BoardColumn>())
                        {     
                            kanbanBoardDomainContext.BoardColumns.Remove(columnItem);
                        }
                        break;
                    }                
            }
            
            kanbanBoardDomainContext.SubmitChanges();
        }
    }
}