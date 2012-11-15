using KanbanBoard.ViewModel;
using System.Windows.Controls;

namespace KanbanBoard.Views.Controls
{
    public partial class ColumnControl : UserControl
    {
        public ColumnControl()
        {
            InitializeComponent();
            var boards = new string[] { "fakeItem1", "fakeItem2", "fakeItem3" };

            var fakeViewModel = new ColumnControlViewModel<string>("fake column",boards);

            // ToDo : Remove fake viewmodel and paste real

            this.DataContext = fakeViewModel;
        }

        public ColumnControl(BaseViewModel viewModel)
            : this()
        {
            this.DataContext = viewModel;
        }
    }
}
