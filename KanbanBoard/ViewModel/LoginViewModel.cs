
using KanbanBoard.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
namespace KanbanBoard.ViewModel
{
    public class LoginViewModel : BaseViewModel, INavigationAware
    {
        private readonly ILoginController controller;

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

        public LoginViewModel(ILoginController loginController)
            : base()
        {
            this.controller = loginController;
            LoginCommand = new DelegateCommand(() =>
            {
                LoginOperation loginOp = WebContextBase.Current.Authentication.Login(new LoginParameters(UserName, Password, true, ""),
                    loginOperation => controller.OnLoginCompleted(loginOperation), null);
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
          
        }
    }
}