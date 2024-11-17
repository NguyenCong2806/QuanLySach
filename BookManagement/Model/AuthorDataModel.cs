using BookManagement.Data.Dto;
using BookManagement.Utilities;
using System.Collections.ObjectModel;

namespace BookManagement.Model
{
    public class AuthorDataModel : ViewModelBase
    {
        private ObservableCollection<AuthorDto> _comboBoxAuthorItemSource;

        public ObservableCollection<AuthorDto> ComboBoxAuthorItemSource
        {
            get { return _comboBoxAuthorItemSource; }
            set
            {
                _comboBoxAuthorItemSource = value;
                OnPropertyChanged(nameof(ComboBoxAuthorItemSource));
            }
        }
        public AuthorDataModel()
        {
            _comboBoxAuthorItemSource = new ObservableCollection<AuthorDto>();
        }
    }
}