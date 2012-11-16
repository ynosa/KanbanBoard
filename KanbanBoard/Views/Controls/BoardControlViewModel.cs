using KanbanBoard.ViewModel;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace KanbanBoard.Views.Controls
{
    public class BoardControlViewModel : BaseViewModel
    {
        private readonly InteractionRequest<Confirmation> confirmDeleteColumn;

        public ObservableCollection<UserControl> ColumnsCollection { get; set; }

        public DelegateCommand AddColumnCommand { get; set; }
        public DelegateCommand EditColumnCommand { get; set; }
        public DelegateCommand RemoveColumnCommand { get; set; }

        public BoardControlViewModel()
            : base()
        {
            confirmDeleteColumn = new InteractionRequest<Confirmation>();

            AddColumnCommand = new DelegateCommand(() => AddColumn());
            EditColumnCommand = new DelegateCommand(() => EditColumn());
            RemoveColumnCommand = new DelegateCommand(() => RemoveColumn());

            ColumnsCollection = new ObservableCollection<UserControl>();
            ColumnsCollection.Add(new ColumnControl());
            ColumnsCollection.Add(new ColumnControl());
            ColumnsCollection.Add(new ColumnControl());
        }

        public BoardControlViewModel(int columnCount)
            : this()
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
}
