using KanbanBoard.ViewModel;
using System.Windows.Controls;

namespace KanbanBoard.Views
{
    public partial class BoardsView : UserControl
    {
        public BoardsView(BoardsListViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
