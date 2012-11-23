using System.Collections.Specialized;
using System.Linq;
using Microsoft.Practices.Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace KanbanBoard.Shell.RegionAdapters
{
    public class GridRegionAdapter : RegionAdapterBase<Grid>
    {
        public GridRegionAdapter(IRegionBehaviorFactory behaviorFactory) :
            base(behaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, Grid regionTarget)
        {
            region.ActiveViews.CollectionChanged +=
            (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
                {
                    regionTarget.Children.Clear();
                    regionTarget.Children.Add((UIElement)region.ActiveViews.First());
                }
            };
            region.Views.CollectionChanged +=
            (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add && region.ActiveViews.Count() == 0)
                {
                    region.Activate(e.NewItems[0]);
                }
            };
        }
        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }

    }
}
