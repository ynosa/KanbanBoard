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
        private readonly InteractionRequest<Confirmation> columnDialog;

        public ObservableCollection<UserControl> ColumnCollection { get; set; }

        public DelegateCommand AddColumn { get; set; }
        public DelegateCommand EditColumn { get; set; }
        public DelegateCommand RemoveColumn { get; set; }

        public BoardControlViewModel()
            : base()
        {
            confirmDeleteColumn = new InteractionRequest<Confirmation>();
            columnDialog = new InteractionRequest<Confirmation>();
            InitializeCommands();
        }

        public BoardControlViewModel(int columnCount)
            : this()
        {
            ColumnCollection = new ObservableCollection<UserControl>();
        }

        private void InitializeCommands()
        {
            AddColumn = new DelegateCommand(() =>
            {
                // ToDo : Add implementation on adding new column.
            });

            EditColumn = new DelegateCommand(() =>
            {
                // ToDo : Add implementation on editing column.
            });

            RemoveColumn = new DelegateCommand(() =>
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
            });
        }
    }
}
