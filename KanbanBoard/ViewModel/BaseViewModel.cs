using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.ComponentModel;

namespace KanbanBoard.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void ChangeRegion(string regionName, Uri regionUri)
        {
            RegionManager.RequestNavigate(regionName, regionUri);
        }
    }
}