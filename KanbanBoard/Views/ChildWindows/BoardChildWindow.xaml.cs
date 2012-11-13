using KanbanBoard.ViewModel;
using System.Windows.Controls;

namespace KanbanBoard.Views.ChildWindows
{
    public partial class BoardChildWindow : ChildWindow
    {
        public BoardChildWindow(BoardViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}

