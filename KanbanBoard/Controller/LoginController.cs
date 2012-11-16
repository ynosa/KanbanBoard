using KanbanBoard.Events;
using KanbanBoard.Helpers;
using KanbanBoard.Interfaces;
using Microsoft.Practices.Prism.Events;
using System.ServiceModel.DomainServices.Client.ApplicationServices;

namespace KanbanBoard.Controller
{
    public class LoginController : ILoginController
    {
        private readonly IEventAggregator eventAggregator;
        private readonly ViewOrchestrator viewOrchestrator;

        public LoginController(IEventAggregator eventAggregator, ViewOrchestrator orchestrator)
        {
            this.eventAggregator = eventAggregator;
            this.viewOrchestrator = orchestrator;
            this.eventAggregator.GetEvent<AuthenticationEvent>().Subscribe(RaiseAuthentification, true);
        }

        private void RaiseAuthentification(int a)
        {
            WebContextBase.Current.Authentication.LoadUser(Application_UserLoaded, null);
        }

        public void Application_UserLoaded(LoadUserOperation operation)
        {
            if (operation.User.Identity.IsAuthenticated)
            {
                // implement switch to views
                viewOrchestrator.ChangeView(RegionNames.MAIN_REGION, "BoardsView");
                viewOrchestrator.ChangeView(RegionNames.HEADER_REGION, "StatusView", string.Format(viewOrchestrator.ParametrTemplate, "USERNAME", operation.User.Identity.Name));
            }
            else
            {
                // implement switch to views
                viewOrchestrator.ChangeView(RegionNames.MAIN_REGION, "LoginView");
            }
        }

        public void OnLoginCompleted(LoginOperation operation)
        {
            if (operation.HasError)
            {
                viewOrchestrator.ChangeView(RegionNames.MAIN_REGION, "ErrorView", string.Format(viewOrchestrator.ParametrTemplate, "MESSAGE", operation.Error.Message));
                operation.MarkErrorAsHandled();
                return;
            }
            else if (!operation.LoginSuccess)
            {
                viewOrchestrator.ChangeView(RegionNames.MAIN_REGION, "ErrorView", string.Format(viewOrchestrator.ParametrTemplate, "MESSAGE", "Incorrect username or password!"));
                return;
            }
            else
            {
                viewOrchestrator.ChangeView(RegionNames.MAIN_REGION, "BoardsView");
                viewOrchestrator.ChangeView(RegionNames.HEADER_REGION, "StatusView", string.Format(viewOrchestrator.ParametrTemplate, "USERNAME", operation.User.Identity.Name));
            }
        }

        public void OnLogoutCompleted(LogoutOperation operation)
        {
            viewOrchestrator.ChangeView(RegionNames.MAIN_REGION, "LoginView");
            viewOrchestrator.DeactivateView(RegionNames.HEADER_REGION, "StatusView");
        }
    }
}
