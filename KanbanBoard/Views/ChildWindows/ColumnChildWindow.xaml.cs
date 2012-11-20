using System.Windows.Controls;

namespace KanbanBoard.Views.ChildWindows
{
    public partial class ColumnChildWindow : ChildWindow
    {
        public ColumnChildWindow()
        {
            InitializeComponent();
            this.oKButton.Click += (s, e) => this.DialogResult = true;
            this.cancelButton.Click += (s, e) => this.DialogResult = false;
        }

        public string ColumnName
        {
            get { return this.columnName.Text; }
            set { this.columnName.Text = value; }
        }
      
    }
}

