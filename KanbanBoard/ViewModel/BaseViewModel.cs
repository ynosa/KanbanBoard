using Microsoft.Practices.Prism;
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

        public void ChangeRegion(string regionName, string viewName, params string[] args)
        {
            UriQuery query = new UriQuery();

            foreach (var item in args)
            {
                var splited = item.Split(':');
                if (splited.Length > 1)
                    query.Add(splited[0], splited[1]);
            }

            RegionManager.RequestNavigate(regionName, new Uri(viewName + query.ToString(), System.UriKind.Relative));
        }
    }
}