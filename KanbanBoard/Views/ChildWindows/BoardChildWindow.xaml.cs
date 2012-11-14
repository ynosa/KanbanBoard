using KanbanBoard.ViewModel;
using System.Windows.Controls;

namespace KanbanBoard.Views.ChildWindows
{
    public partial class BoardChildWindow : ChildWindow
    {
        public BoardChildWindow()
        {
            InitializeComponent();
        }
        public BoardChildWindow(BoardViewModel viewModel)
            : this()
        {
            this.DataContext = viewModel;
        }
    }
}

