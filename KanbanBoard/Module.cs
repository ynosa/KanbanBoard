using KanbanBoard.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

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
            // ToDo : Add initialization logic
            this.regionManager.RegisterViewWithRegion(RegionNames.HEADER_REGION, () => this.container.Resolve<HeaderView>());
            this.regionManager.RegisterViewWithRegion(RegionNames.MAIN_REGION, () => this.container.Resolve<BoardsView>());
        }
    }
}
