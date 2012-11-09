
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
namespace KanbanBoard.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        //TODO : Add implementation

        public string UserName { get; set; }
        public string Password { get; set; }

        public DelegateCommand LoginCommand { get; private set; }

        public LoginViewModel(IRegionManager manager):base(manager)
        {
            LoginCommand = new DelegateCommand(() => 
            {
                ChangeRegion(RegionNames.MAIN_REGION, new System.Uri("BoardsView",System.UriKind.Relative));
            });
        }
    }
}