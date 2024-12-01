using BookManagement.Data;
using BookManagement.Data.Dto;
using System.Collections.ObjectModel;

namespace BookManagement.Model
{
    public class EmployeeModel : DataModel<EmployeeDto>
    {
        private string _hiddenPage;

        public string HiddenPage
        {
            get { return _hiddenPage; }
            set
            {
                _hiddenPage = value;
                OnPropertyChanged(nameof(HiddenPage));
            }
        }
        private string _visiblePage;

        public string VisiblePage
        {
            get { return _visiblePage; }
            set
            {
                _visiblePage = value;
                OnPropertyChanged(nameof(VisiblePage));
            }
        }
        public EmployeeModel()
        {
            Model = new EmployeeDto();
            Models = new ObservableCollection<EmployeeDto>();
        }
    }
}
