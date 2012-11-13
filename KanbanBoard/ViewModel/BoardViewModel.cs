using Microsoft.Practices.Prism.Commands;

namespace KanbanBoard.ViewModel
{
    public class BoardViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string BoardTitle { get; set; }

        public DelegateCommand ApplyCommand { get; set; }

        public BoardViewModel()
            : base()
        {
            // ToDo : Add implementation
        }
    }
}
