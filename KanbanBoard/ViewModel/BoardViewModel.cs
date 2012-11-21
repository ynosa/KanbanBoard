
using KanbanBoard.Views.ChildWindows;
using KanbanBoard.Web;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
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
    
    public class BoardViewModel : BaseViewModel, INavigationAware
    {
        private readonly InteractionRequest<Confirmation> confirmDeleteColumn;
        private readonly InteractionRequest<Confirmation> confirmDeleteTask;
        private KanbanBoardDomainContext kanbanBoardDomainContext = new KanbanBoardDomainContext();
        private Guid BoardId;
        private readonly IUnityContainer container;
        private ObservableCollection<BoardColumn> _boardsColumns;

        public static string BoardIdParam = "BoardId";

        public DelegateCommand AddNewColumnCommand { get; set; }
        public DelegateCommand<BoardColumn> RemoveColumnCommand { get; set; }
        public DelegateCommand<BoardColumn> AddNewTaskCommand { get; set; }
        public DelegateCommand<Task> RemoveTaskCommand { get; set; }

        public InteractionRequest<Confirmation> ConfirmDeleteColumn
        {
            get { return confirmDeleteColumn; }
        }

        public InteractionRequest<Confirmation> ConfirmDeleteTask
        {
            get { return confirmDeleteTask; }
        }


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

        public BoardViewModel(IUnityContainer container)
            : base()
        {
            this.container = container;
            AddNewColumnCommand = new DelegateCommand(AddNewColumn);
            RemoveColumnCommand = new DelegateCommand<BoardColumn>(RemoveColumn);

            AddNewTaskCommand = new DelegateCommand<BoardColumn>(AddNewTask);
            RemoveTaskCommand = new DelegateCommand<Task>(RemoveTask);

            confirmDeleteColumn = new InteractionRequest<Confirmation>();
            confirmDeleteTask = new InteractionRequest<Confirmation>();
        }

        private void AddNewColumn()
        {
            var childWindow = container.Resolve<ColumnChildWindow>();
            childWindow.Title = "add new column";
            childWindow.Closed += (s, e) =>
            {
                if (childWindow.DialogResult == true)
                {
                    var task = new BoardColumn()
                        {
                            BoardId = BoardId,
                            Name = childWindow.ColumnName
                        };
                    // ToDo: Add implementation of the adding new column functionality
                    //kanbanBoardDomainContext.Tasks.Add(task);
                    //kanbanBoardDomainContext.SubmitChanges();
                }
            };
            childWindow.Show();
        }

        private void RemoveColumn(BoardColumn column)
        {
            confirmDeleteColumn.Raise(new Confirmation()
                {
                    Content = "Are you sure you want to remove this column?"

                }, confirmation =>
                    {
                        if (confirmation.Confirmed)
                        {
                            kanbanBoardDomainContext.BoardColumns.Remove(column);
                            kanbanBoardDomainContext.SubmitChanges();
                        }
                    });
        }

        private void AddNewTask(BoardColumn column)
        {
            var childWindow = container.Resolve<TaskChildWindow>();
            childWindow.Title = "add new task";
            childWindow.Closed += (s, e) =>
                {
                    if (childWindow.DialogResult == true)
                    {
                        var task = new Task()
                            {
                                BoardColumnId = column.Id,
                                Name = childWindow.TaskName
                            };
                        // ToDo: Add implementation of the adding new task functionality
                        //kanbanBoardDomainContext.Tasks.Add(task);
                        //kanbanBoardDomainContext.SubmitChanges();
                    }
                };
            childWindow.Show();
        }

        private void RemoveTask(Task task)
        {
            confirmDeleteTask.Raise(new Confirmation()
                {
                    Content = "Are you sure you want to remove this task?"
                }, confirmation =>
                    {
                        if (confirmation.Confirmed)
                        {
                            // kanbanBoardDomainContext.Tasks.Remove(task);
                            // kanbanBoardDomainContext.SubmitChanges();
                        }
                    }
                );
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