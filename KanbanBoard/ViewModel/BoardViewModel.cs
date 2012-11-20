
using KanbanBoard.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System.ServiceModel.DomainServices.Client.ApplicationServices;

namespace KanbanBoard.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceModel.DomainServices.Client;

    using KanbanBoard.Web;

    public class BoardViewModel : BaseViewModel, INavigationAware
    {
        public static string BoardIdParam = "BoardId";

        private Guid BoardId;

        public ObservableCollection<BoardColumn> BoardColumns { get; set; }

        private KanbanBoardDomainContext kanbanBoardDomainContext = new KanbanBoardDomainContext();

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
            this.ProcessBoardItems();           
        }

        public void ProcessBoardItems()
        {
            kanbanBoardDomainContext.Load(kanbanBoardDomainContext.GetBoardColumnsQuery().Where(obj => obj.BoardId == this.BoardId), this.OnProcessed, null);   
        }

        public virtual void OnProcessed(LoadOperation<BoardColumn> operation)
        {
             this.BoardColumns=new ObservableCollection<BoardColumn>(operation.Entities);            
        }
    }
}