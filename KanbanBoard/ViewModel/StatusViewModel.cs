using KanbanBoard.Events;
using KanbanBoard.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using System.ServiceModel.DomainServices.Client.ApplicationServices;

namespace KanbanBoard.ViewModel
{
    public class StatusViewModel : BaseViewModel,INavigationAware
    {
        private string name;
        private readonly ILoginController controller;
        private readonly IEventAggregator eventAggregator;

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
        public DelegateCommand ShowBoardsCommand { get; private set; }

        public StatusViewModel(ILoginController loginController, IEventAggregator eventAggregator)
            : base()
        {
            this.controller = loginController;
            this.eventAggregator = eventAggregator;
            LogOutCommand = new DelegateCommand(() =>
            {
                WebContextBase.Current.Authentication.Logout(controller.OnLogoutCompleted, null);
            });

            ShowBoardsCommand = new DelegateCommand(ShowBoards);
        }

        private void ShowBoards()
        {
            this.eventAggregator.GetEvent<ShowBoardsEvent>().Publish(0);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            UserName = string.Format("Hi, {0}!",navigationContext.Parameters["USERNAME"]);
        }
    }
}
