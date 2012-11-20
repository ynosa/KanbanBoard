using System.Windows.Controls;

namespace KanbanBoard.Views.ChildWindows
{
    public partial class TaskChildWindow : ChildWindow
    {
        public TaskChildWindow()
        {
            InitializeComponent();
            this.oKButton.Click += (s, e) => this.DialogResult = true;
            this.cancelButton.Click += (s, e) => this.DialogResult = false;
        }

        public string TaskName
        {
            get { return this.taskName.Text; }
            set { this.taskName.Text = value; }
        }
    }
}

