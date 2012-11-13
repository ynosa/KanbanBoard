using System.ServiceModel.DomainServices.Client.ApplicationServices;

namespace KanbanBoard.Interfaces
{
    public interface ILoginController
    {
        void OnLoginCompleted(LoginOperation operation);
        void OnLogoutCompleted(LogoutOperation operation);
    }
}
