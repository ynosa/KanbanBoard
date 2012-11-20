using KanbanBoard.ViewModel;
using System.Windows.Controls;

namespace KanbanBoard.Views
{
    public partial class BoardView : UserControl
    {
        public BoardView(BoardViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
