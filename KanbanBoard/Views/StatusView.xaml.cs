using KanbanBoard.ViewModel;
using System.Windows.Controls;

namespace KanbanBoard.Views
{
    public partial class StatusView : UserControl
    {
        public StatusView(LoginViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
