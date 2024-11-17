using System;
using System.Linq;

namespace BookManagement.Data.Dto
{
    public class BookDto : ValidatableBindableBase
    {
        private Guid _bookcode;
        public Guid Bookcode
        {
            get { return _bookcode; }
            set
            {
                _bookcode = value;
            }
        }
        private string _bookName;

        public string BookName
        {
            get { return _bookName; }
            set
            {
                _bookName = value;
                RaisePropertyChanged();
            }
        }
        private Guid _bookGenrecode;

        public Guid BookGenrecode
        {
            get { return _bookGenrecode; }
            set
            {
                _bookGenrecode = value;
                RaisePropertyChanged();
            }
        }

        private Guid _suppliercode;

        public Guid Suppliercode
        {
            get { return _suppliercode; }
            set
            {
                _suppliercode = value;
                RaisePropertyChanged();
            }
        }

        private Guid _authorcode;

        public Guid Authorcode
        {
            get { return _authorcode; }
            set
            {
                _authorcode = value;
                RaisePropertyChanged();
            }
        }

        private Guid _bookPublishercode;

        public Guid BookPublishercode
        {
            get { return _bookPublishercode; }
            set
            {
                _bookPublishercode = value;
                RaisePropertyChanged();
            }
        }

        private int? _quanity;

        public int? Quanity
        {
            get { return _quanity; }
            set
            {
                _quanity = value;
                RaisePropertyChanged();
            }
        }
        private int? _yearOfPublication;

        public int? YearOfPublication
        {
            get { return _yearOfPublication; }
            set
            {
                _yearOfPublication = value;
                RaisePropertyChanged();
            }
        }
        private string _imageUrl;

        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                RaisePropertyChanged();
            }
        }
        private AuthorDto _authorDto;

        public AuthorDto AuthorDto
        {
            get { return _authorDto; }
            set
            {
                _authorDto = value;
                RaisePropertyChanged();
            }
        }
        private BookGenreDto _bookGenreDto;

        public BookGenreDto BookGenreDto
        {
            get { return _bookGenreDto; }
            set
            {
                _bookGenreDto = value;
                RaisePropertyChanged();
            }
        }
        public void ValidateBookName()
        {
            ClearErrors(nameof(BookName));
            if (string.IsNullOrEmpty(BookName))
                AddError(nameof(BookName), "Không được bỏ trống!");
            if (BookName?.Length > 256)
                AddError(nameof(BookName), "Vượt quá 256 ký tự!");
        }
        
        public BookPublisherDto BookPublisherDto { get; set; }
        public SupplierDto SupplierDto { get; set; }
    }
}
