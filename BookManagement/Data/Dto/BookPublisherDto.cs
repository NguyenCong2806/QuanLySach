using System;

namespace BookManagement.Data.Dto
{
    public class BookPublisherDto : ValidatableBindableBase
    {
        private Guid _bookPublishercode;

        public Guid BookPublishercode
        {
            get { return _bookPublishercode; }
            set
            {
                _bookPublishercode = value;
            }
        }

        private string _bookPublisherName;

        public string BookPublisherName
        {
            get { return _bookPublisherName; }
            set
            {
                _bookPublisherName = value;
                RaisePropertyChanged();
            }
        }

        public void ValidateBookGenreName()
        {
            ClearErrors(nameof(BookPublisherName));
            if (string.IsNullOrEmpty(BookPublisherName))
                AddError(nameof(BookPublisherName), "Không được bỏ trống!");
            if (BookPublisherName?.Length > 256)
                AddError(nameof(BookPublisherName), "Vượt quá 256 ký tự!");
        }
    }
}