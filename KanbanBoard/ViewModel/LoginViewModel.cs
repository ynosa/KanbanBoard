
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
namespace KanbanBoard.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        //TODO : Add implementation
        
        public string UserName { get; set; }
        public string Password { get; set; }

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
                        // TODO : Add error page view.

                        loginOp.MarkErrorAsHandled();
                        return;
                    }
                    else if (!loginOp.LoginSuccess)
                    {
                        return;
                    }
                    else
                    {
                        ChangeRegion(RegionNames.MAIN_REGION, new System.Uri("BoardsView", System.UriKind.Relative));
                    }
                };
            });

            
        }
    }
}