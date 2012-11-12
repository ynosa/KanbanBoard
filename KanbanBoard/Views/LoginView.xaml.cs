using KanbanBoard.ViewModel;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;

namespace KanbanBoard.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView(LoginViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
