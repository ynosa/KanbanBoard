using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;

namespace KanbanBoard.ViewModel
{
    public class ErrorViewModel : BaseViewModel, INavigationAware
    {
        private string message;
        private IRegionNavigationService navigationService;

        public string ErrorType { get; set; }
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                NotifyPropertyChanged("Message");
            }
        }

        public DelegateCommand OkCommand { get; private set; }

        public ErrorViewModel()
            : base()
        {
            OkCommand = new DelegateCommand(() => 
            {
                if (navigationService.Journal.CanGoBack)
                {
                    navigationService.Journal.GoBack();
                }
            });
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
            //throw new System.NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new System.NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            navigationService = navigationContext.NavigationService;
            Message = navigationContext.Parameters["MESSAGE"];
        }
    }
}
