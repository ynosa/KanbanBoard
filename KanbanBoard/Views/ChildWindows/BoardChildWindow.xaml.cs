using KanbanBoard.ViewModel;
using System.Windows.Controls;

namespace KanbanBoard.Views.ChildWindows
{
    public partial class BoardChildWindow : ChildWindow
    {
        public BoardChildWindow()
        {
            InitializeComponent();
            this.oKButton.Click += (s, e) => this.DialogResult = true;
            this.cancelButton.Click += (s, e) => this.DialogResult = false;
        }

        public string BoardName 
        {
            get { return this.boardName.Text; }
            set { this.boardName.Text = value; }
        }
    }
}

