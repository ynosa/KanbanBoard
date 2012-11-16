using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;

namespace KanbanBoard.ViewModel
{
    public class BoardViewModel : BaseViewModel, INavigationAware
    {
        public BoardViewModel()
            : base()
        {
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
            //throw new System.NotImplementedException();
        }
    }
}
