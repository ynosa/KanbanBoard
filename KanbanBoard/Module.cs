using KanbanBoard.ViewModel;
using KanbanBoard.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;

namespace KanbanBoard
{
    public class Module : IModule
    {
        IUnityContainer container;
        IRegionManager regionManager;

        public Module(IUnityContainer container, IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            container.RegisterType<object, StatusView>("StatusView");
            container.RegisterType<object, LoginView>("LoginView");
            container.RegisterType<object, BoardsView>("BoardsView");
            container.RegisterType<object, ErrorView>("ErrorView");

            regionManager.Regions[RegionNames.HEADER_REGION].RequestNavigate(new Uri("StatusView", UriKind.Relative));
            regionManager.Regions[RegionNames.MAIN_REGION].RequestNavigate(new Uri("LoginView", UriKind.Relative));
        }
    }
}