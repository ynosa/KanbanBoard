using KanbanBoard.ViewModel;
using System.Windows.Controls;

namespace KanbanBoard.Views
{
    public partial class StatusView : UserControl
    {
        public StatusView(StatusViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
