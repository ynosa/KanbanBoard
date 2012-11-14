using KanbanBoard.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System.ServiceModel.DomainServices.Client.ApplicationServices;

namespace KanbanBoard.ViewModel
{
    public class StatusViewModel : BaseViewModel
    {
        private string name;
        private readonly ILoginController controller;

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

        public StatusViewModel(ILoginController loginController)
            : base()
        {
            this.controller = loginController;
            LogOutCommand = new DelegateCommand(() =>
            {
                WebContextBase.Current.Authentication.Logout(controller.OnLogoutCompleted, null);
            });
        }
    }
}
