using KanbanBoard.ViewModel;
using KanbanBoard.Web;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Controls;

namespace KanbanBoard.Views.Controls
{
    public class BoardControlViewModel : BaseViewModel
    {
        private readonly InteractionRequest<Confirmation> confirmDeleteColumn;

        public ObservableCollection<Column> ColumnsCollection { get; set; }

        public DelegateCommand AddColumnCommand { get; set; }
        public DelegateCommand EditColumnCommand { get; set; }
        public DelegateCommand RemoveColumnCommand { get; set; }
        private KanbanBoardDomainContext kanbanBoardDomainContext = new KanbanBoardDomainContext();

        public BoardControlViewModel()
            : base()
        {
            confirmDeleteColumn = new InteractionRequest<Confirmation>();

            AddColumnCommand = new DelegateCommand(AddColumn);
            EditColumnCommand = new DelegateCommand(EditColumn);
            RemoveColumnCommand = new DelegateCommand(RemoveColumn);

        }

        public BoardControlViewModel(int columnCount)
            : this()
        {

        }

        public BoardControlViewModel(IEnumerable<BoardColumn> columns)
            : this()
        {
            foreach (var item in columns)
            {
                //ColumnsCollection.Add(new ColumnControl(new ColumnControlViewModel<Task>(item.Name)));
            }
        }

        private void InitBoardColumns()
        {

        }

        private void AddColumn()
        {
            // ToDo :  Add implementation
        }

        private void EditColumn()
        {
            // ToDo :  Add implementation
        }

        private void RemoveColumn()
        {
            confirmDeleteColumn.Raise(new Confirmation()
            {
                Content = "Are you sure you want remove column?",
                Title = "Confirmation"
            },
            confirmation =>
            {
                if (confirmation.Confirmed)
                {
                    // ToDo : Add implementation on removing column.
                }
            });
        }
    }

    public class Column
    {
        public EntityCollection<Task> Tasks { get; set; }
        public string ColumnTitle { get; set; }
    }

    public class Task
    {
        public string TaskTitle { get; set; }
    }
}
