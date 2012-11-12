using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System.ServiceModel.DomainServices.Client.ApplicationServices;

namespace KanbanBoard.ViewModel
{
    public class StatusViewModel : BaseViewModel
    {
        private string name = "";
        
        public string UserName 
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("UserName");
            }
        }

        public DelegateCommand LogOutCommand { get; private set; }

        public StatusViewModel()
            : base()
        {

            UserName = WebContextBase.Current.Authentication.User.Identity.Name;

            WebContextBase.Current.Authentication.LoggedOut += (s, e) =>
            {
                UserName = string.Empty;
                ChangeView(RegionNames.MAIN_REGION, "LoginView");
                DeactivateView(RegionNames.HEADER_REGION, "StatusView");
            };

            LogOutCommand = new DelegateCommand(() => 
            {
                WebContextBase.Current.Authentication.Logout(false);
            });
        }
    }
}
