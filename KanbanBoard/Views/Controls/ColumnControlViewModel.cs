using KanbanBoard.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace KanbanBoard.Views.Controls
{
    public class ColumnControlViewModel<TEntity> : BaseViewModel
    {
        private ObservableCollection<TEntity> entityList;
        private string columnTitle;
        private Guid columnId;

        public string ColumnTitle
        {
            get { return columnTitle; }
            set
            {
                columnTitle = value;
                NotifyPropertyChanged("ColumnTitle");
            }
        }

        public ObservableCollection<TEntity> EntityList
        {
            get { return entityList; }
            set
            {
                entityList = value;
                NotifyPropertyChanged("EntityList");
            }
        }

        public ColumnControlViewModel()
            : base()
        {
            entityList = new ObservableCollection<TEntity>();
            entityList.CollectionChanged += entityList_CollectionChanged;
        }

        public ColumnControlViewModel(string columnTitle)
            : this()
        {
            ColumnTitle = columnTitle;
        }

        public ColumnControlViewModel(string columnTitle, IEnumerable<TEntity> collection)
            : this(columnTitle)
        {
            foreach (var item in collection)
            {
                entityList.Add(item);
            }
        }

        void entityList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // ToDo : Add implementation when collection is changed.
        }
    }
}
