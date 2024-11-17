using BookManagement.Data;
using BookManagement.Data.Dto;
using System.Collections.ObjectModel;

namespace BookManagement.Model
{
    public class BookModel : DataModel<BookDto>
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
        private AuthorDto _authorDto;

        public AuthorDto AuthorDto
        {
            get { return _authorDto; }
            set
            {
                _authorDto = value;
                OnPropertyChanged(nameof(AuthorDto));
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

        private ObservableCollection<BookGenreDto> _comboBoxBookGenreItemSource;

        public ObservableCollection<BookGenreDto> ComboBoxBookGenreItemSource
        {
            get { return _comboBoxBookGenreItemSource; }
            set
            {
                _comboBoxBookGenreItemSource = value;
                OnPropertyChanged(nameof(ComboBoxBookGenreItemSource));
            }
        }

        private ObservableCollection<SupplierDto> _comboBoxSupplierItemSource;

        public ObservableCollection<SupplierDto> ComboBoxSupplierItemSource
        {
            get { return _comboBoxSupplierItemSource; }
            set
            {
                _comboBoxSupplierItemSource = value;
                OnPropertyChanged(nameof(ComboBoxSupplierItemSource));
            }
        }

        private ObservableCollection<BookPublisherDto> _comboBoxBookPublisherItemSource;

        public ObservableCollection<BookPublisherDto> ComboBoxBookPublisherItemSource
        {
            get { return _comboBoxBookPublisherItemSource; }
            set
            {
                _comboBoxBookPublisherItemSource = value;
                OnPropertyChanged(nameof(ComboBoxBookPublisherItemSource));
            }
        }

        public BookModel()
        {
            Model = new BookDto();
            Models = new ObservableCollection<BookDto>();
            ComboBoxAuthorItemSource = new ObservableCollection<AuthorDto>();
            ComboBoxBookGenreItemSource = new ObservableCollection<BookGenreDto>();
            ComboBoxSupplierItemSource = new ObservableCollection<SupplierDto>();
            ComboBoxBookPublisherItemSource = new ObservableCollection<BookPublisherDto>();
        }
    }
}