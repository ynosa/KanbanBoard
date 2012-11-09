using Microsoft.Practices.Prism.Commands;

namespace KanbanBoard.ViewModel
{
    public class StatusViewModel : BaseViewModel
    {
        public DelegateCommand LogOutCommand { get; protected set; }

        public StatusViewModel()
        {
                
        }

    }
}
