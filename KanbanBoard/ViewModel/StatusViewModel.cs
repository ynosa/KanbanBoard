using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;

namespace KanbanBoard.ViewModel
{
    public class StatusViewModel : BaseViewModel
    {
        //TODO : Add implementation

        public DelegateCommand LogOutCommand { get; private set; }

        public StatusViewModel(IRegionManager manager)
            : base(manager)
        {
                
        }
    }
}
