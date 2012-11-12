
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
namespace KanbanBoard.ViewModel
{
    public class LoginViewModel : BaseViewModel, INavigationAware
    {
        
        private const string ERROR_TEMPLATE = "{0}:{1}";
        
        private string userName;
        private string password;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyPropertyChanged("UserName");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public DelegateCommand LoginCommand { get; private set; }

        public LoginViewModel()
            : base()
        {
            LoginCommand = new DelegateCommand(() =>
            {
                LoginOperation loginOp = WebContextBase.Current.Authentication.Login(new LoginParameters(UserName, Password));
                loginOp.Completed += (s2, e2) =>
                {
                    if (loginOp.HasError)
                    {
                        ChangeView(RegionNames.MAIN_REGION, "ErrorView", string.Format(ERROR_TEMPLATE,"MESSAGE",loginOp.Error.Message));
                        loginOp.MarkErrorAsHandled();
                        return;
                    }
                    else if (!loginOp.LoginSuccess)
                    {
                        ChangeView(RegionNames.MAIN_REGION, "ErrorView", string.Format(ERROR_TEMPLATE, "MESSAGE", "Incorrect username or password!"));
                        return;
                    }
                    else
                    {
                        ChangeView(RegionNames.MAIN_REGION, "BoardsView");
                        ChangeView(RegionNames.HEADER_REGION, "StatusView");
                    }
                };
            });


        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
            //throw new System.NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // Sets started params
            UserName = string.Empty;
            Password = string.Empty;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new System.NotImplementedException();
        }
    }
}