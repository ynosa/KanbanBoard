using Microsoft.Practices.Prism.Commands;

namespace KanbanBoard.ViewModel
{
    public class BoardViewModel : BaseViewModel
    {
        private bool? dialogResult;
        private string windowTitle;

        public string WindowTitle
        {
            get { return windowTitle; }
            set
            {
                windowTitle = value;
                NotifyPropertyChanged("WindowTitle");
            }
        }
        public bool? DialogResult
        {
            get { return dialogResult; }
            set
            {
                dialogResult = value;
                NotifyPropertyChanged("DialogResult");
            }
        }

        public DelegateCommand ApplyCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public BoardViewModel()
            : base()
        {
            CancelCommand = new DelegateCommand(() => 
            {
                // ToDo : Add implementation when dialog result is false.
                DialogResult = false;
            });
            // ToDo : Add implementation for other component.
        }
    }
}
