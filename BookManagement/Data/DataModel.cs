using BookManagement.Utilities;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace BookManagement.Data
{
    public abstract class DataModel<TModel> : ViewModelBase
        where TModel : class
    {
        private bool _isEnableNext;

        public bool IsEnableNext
        {
            get { return _isEnableNext; }
            set
            {
                _isEnableNext = value;
                OnPropertyChanged(nameof(IsEnableNext));
            }
        }

        private bool _isEnablePrevious;

        public bool IsEnablePrevious
        {
            get { return _isEnablePrevious; }
            set
            {
                _isEnablePrevious = value;
                OnPropertyChanged(nameof(IsEnablePrevious));
            }
        }

        private int _pageIndex { get; set; }

        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                _pageIndex = value;
                OnPropertyChanged(nameof(PageIndex));
            }
        }

        private int _pageSize { get; set; }

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                OnPropertyChanged(nameof(PageSize));
            }
        }

        private TModel _model;

        public TModel Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        private ObservableCollection<TModel> _models;

        public ObservableCollection<TModel> Models
        {
            get
            {
                return _models;
            }
            set
            {
                _models = value;
                OnPropertyChanged(nameof(Models));
            }
        }

        private void Models_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Models));
        }
    }
}