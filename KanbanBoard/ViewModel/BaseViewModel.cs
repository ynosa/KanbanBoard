using Microsoft.Practices.Prism.Regions;
using System;
using System.ComponentModel;

namespace KanbanBoard.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IRegionManager regionManager;

        public BaseViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void ChangeRegion(string regionName, Uri regionUri)
        {
            regionManager.RequestNavigate(regionName, regionUri);
        }
    }
}