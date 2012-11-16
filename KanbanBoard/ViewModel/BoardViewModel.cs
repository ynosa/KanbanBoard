
using KanbanBoard.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
namespace KanbanBoard.ViewModel
{
    using System;

    public class BoardViewModel : BaseViewModel, INavigationAware
    {       
        public static string  BoardIdParam = "BoardId";

        private Guid BoardId;
        
        public BoardViewModel()
            : base()
        {
            
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
            BoardId = Guid.Parse(navigationContext.Parameters[BoardIdParam]);
        }
    }
}