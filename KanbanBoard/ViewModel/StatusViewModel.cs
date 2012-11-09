using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;

namespace KanbanBoard.ViewModel
{
    public class StatusViewModel : BaseViewModel
    {
        //TODO : Add implementation

        private string name;

        public string Uname 
        {
            get
            {
                return name;
            }

            set
            {
                if (!string.IsNullOrEmpty(name))
                {
                    name = value;
                    //NotifyPropertyChanged("Uname");
                }
            }
        }

        public DelegateCommand LogOutCommand { get; private set; }

        public StatusViewModel(IRegionManager manager)
            : base(manager)
        {
                
        }
    }
}
