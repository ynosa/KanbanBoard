namespace KanbanBoard.ViewModel
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.ServiceModel.DomainServices.Client;
    using System.Threading.Tasks;

    using ISMOT.Silverlight.Threading.Tasks;

    using KanbanBoard.Views.ChildWindows;
    using KanbanBoard.Web;

    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Unity;

    using Task = KanbanBoard.Web.Task;

    #endregion

    public class BoardViewModel : BaseViewModel, INavigationAware
    {
        #region Constants and Fields

        //Subject<> 

        public static string BoardIdParam = "BoardId";

        public static string BoardNameParam = "BoardName";

        private readonly InteractionRequest<Confirmation> confirmDeleteColumn;

        private readonly InteractionRequest<Confirmation> confirmDeleteTask;

        private readonly InteractionRequest<Confirmation> confirmAddBoard;

        private readonly IUnityContainer container;

        private string boardName;

        private Guid BoardId;

        private ObservableCollection<Container<BoardColumn, Task>> _boardColumns;

        private KanbanBoardDomainContext kanbanBoardDomainContext = new KanbanBoardDomainContext();

        #endregion

        #region Constructors and Destructors

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

        #endregion

        #region Public Properties

        public string BoardName
        {
            get { return boardName; }
            set
            {
                boardName = value;
                NotifyPropertyChanged("BoardName");
            }
        }

        public DelegateCommand AddNewColumnCommand { get; set; }

        public DelegateCommand<BoardColumn> AddNewTaskCommand { get; set; }

        public ObservableCollection<Container<BoardColumn, Task>> BoardColumns
        {
            get
            {
                return this._boardColumns;
            }
            set
            {
                this._boardColumns = value;
                this.NotifyPropertyChanged("BoardColumns");
            }
        }

        public InteractionRequest<Confirmation> ConfirmDeleteColumn
        {
            get
            {
                return confirmDeleteColumn;
            }
        }

        public InteractionRequest<Confirmation> ConfirmDeleteTask
        {
            get
            {
                return confirmDeleteTask;
            }
        }

        public DelegateCommand<BoardColumn> RemoveColumnCommand { get; set; }

        public DelegateCommand<Task> RemoveTaskCommand { get; set; }



        #endregion

        #region Public Methods and Operators

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void LoadBoardItems()
        {
            kanbanBoardDomainContext.Load(
                kanbanBoardDomainContext.GetBoardColumnsQuery().Where(obj => obj.BoardId == this.BoardId),
                LoadBehavior.MergeIntoCurrent,
                this.OnLoadBoardItemsCompleted,
                null);
        }

        public virtual void OnLoadBoardItemsCompleted(LoadOperation<BoardColumn> operation)
        {
            this.BoardColumns =
                new ObservableCollection<Container<BoardColumn, Task>>
                    (
                        operation.Entities.Null(new ObservableCollection<BoardColumn>()).Select(board => new Container<BoardColumn, Task>(board, board.Tasks.AsEnumerable().Null(new Task[0]).OrderBy(obj => obj.Position), this.TasksCollectionChanged)).OrderBy(obj => obj.Item.Position)
                    );
        }

        private void TasksCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            var boardColumn = BoardColumns.Single(obj => obj.Children.Equals(sender as ObservableCollection<Task>));

            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        foreach (var item in eventArgs.NewItems.Cast<Task>())
                        {
                            item.BoardColumnId = boardColumn.Item.Id;
                        }

                        SyncTasksPositionInColumn(boardColumn);

                        kanbanBoardDomainContext.SubmitChanges(this.OnSubmitChangesCompleted, null);

                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        SyncTasksPositionInColumn(boardColumn);
                        break;
                    }
            }
        }

        private void SyncTasksPositionInColumn(Container<BoardColumn, Task> boardColumn)
        {

            foreach (var syncItem in boardColumn.Children.Select((obj, i) => new { Element = obj, Position = i }).Where(obj => obj.Position != obj.Element.Position))
            {
                syncItem.Element.Position = (short)syncItem.Position;
            }
        }

        private void OnSubmitChangesCompleted(SubmitOperation submitOperation)
        {
            var a = submitOperation.EntitiesInError;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            BoardId = Guid.Parse(navigationContext.Parameters[BoardIdParam]);
            BoardName = navigationContext.Parameters[BoardNameParam];
            this.LoadBoardItems();
        }

        #endregion

        #region Methods

        private void AddNewColumn()
        {
            var childWindow = container.Resolve<ColumnChildWindow>();
            childWindow.Title = "add new column";
            childWindow.Closed += (s, e) =>
                {
                    if (childWindow.DialogResult == true)
                    {
                        var column = new BoardColumn
                            {
                                Id = Guid.NewGuid(),
                                BoardId = BoardId,
                                Name = childWindow.ColumnName,
                                Position = this.BoardColumns.Count != 0 
                                ? (short)(this.BoardColumns.Max(obj => obj.Item.Position) + 1) 
                                : (short)0
                            };

                        kanbanBoardDomainContext.BoardColumns.Add(column);
                        kanbanBoardDomainContext.SubmitChanges(operation => LoadBoardItems(), null);
                    }
                };
            childWindow.Show();
        }

        private async void AddNewTask(BoardColumn column)
        {
            var childWindow = container.Resolve<TaskChildWindow>();
            childWindow.Title = "add new task";
            childWindow.Closed += async (s, e) =>
                {
                    if (childWindow.DialogResult == true)
                    {
                        var task = new Task
                            {
                                BoardColumnId = column.Id,
                                Name = childWindow.TaskName,
                                Description = "",
                                Id = Guid.NewGuid(),
                                Position = column.Tasks.Count != 0
                                ? (short)(column.Tasks.Max(obj => obj.Position) + 1)
                                : (short)0
                            };

                        if (BoardsListViewModel.HasValidationErrors(task))
                        {
                            childWindow.Show();
                            return; 
                        }

                        kanbanBoardDomainContext.Tasks.Add(task);
                        await kanbanBoardDomainContext.SubmitChangesAsync();
                        this.LoadBoardItems();
                    }
                };
            childWindow.Show();
        }

        private void RemoveColumn(BoardColumn column)
        {
            confirmDeleteColumn.Raise(
                new Confirmation { Content = "Are you sure you want to remove this column?" },
                confirmation =>
                {
                    if (confirmation.Confirmed)
                    {
                        kanbanBoardDomainContext.BoardColumns.Remove(column);
                        kanbanBoardDomainContext.SubmitChanges(operation => LoadBoardItems(), null);
                    }
                });
        }

        private void RemoveTask(Task task)
        {
            confirmDeleteTask.Raise(
                new Confirmation() { Content = "Are you sure you want to remove this task?" },
                confirmation =>
                {
                    if (confirmation.Confirmed)
                    {
                        kanbanBoardDomainContext.Tasks.Remove(task);
                        kanbanBoardDomainContext.SubmitChanges(operation => LoadBoardItems(), null);
                    }
                });
        }

        #endregion
    }

    public class Container<TU, TV>
    {
        #region Constructors and Destructors

        public Container(TU item, IEnumerable<TV> children, NotifyCollectionChangedEventHandler handler)
        {
            Item = item;
            Children = new ObservableCollection<TV>(children);
            Children.CollectionChanged += handler;
        }

        #endregion

        #region Public Properties

        public ObservableCollection<TV> Children { get; set; }

        public TU Item { get; set; }

        #endregion
    }
}