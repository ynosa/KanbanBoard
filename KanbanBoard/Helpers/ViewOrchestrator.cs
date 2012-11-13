using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Linq;
namespace KanbanBoard.Helpers
{
    public class ViewOrchestrator
    {
        private readonly IRegionManager regionManager;

        public string ParametrTemplate
        {
            get { return "{0}:{1}"; }
        }

        public ViewOrchestrator(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void ChangeView(string regionName, string viewName, params string[] args)
        {
            UriQuery query = new UriQuery();

            foreach (var item in args)
            {
                var splited = item.Split(':');
                if (splited.Length > 1)
                    query.Add(splited[0], splited[1]);
            }

            regionManager.RequestNavigate(regionName, new Uri(viewName + query.ToString(), System.UriKind.Relative));
        }

        public void DeactivateView(string regionName, string viewName)
        {
            var currentView = regionManager.Regions[regionName].ActiveViews.FirstOrDefault();
            if (currentView != null)
                regionManager.Regions[regionName].Deactivate(currentView);
        }
    }
}
