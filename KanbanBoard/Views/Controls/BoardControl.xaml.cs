using System.Windows.Controls;

namespace KanbanBoard.Views.Controls
{
    public partial class BoardControl : UserControl
    {
        public BoardControl()
        {
            InitializeComponent();
            this.DataContext = new BoardControlViewModel(); ;
        }
        public BoardControl(BoardControlViewModel viewModel)
            : this()
        {
            
        }
    }
}
