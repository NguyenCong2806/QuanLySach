using System;

namespace BookManagement.Data.Dto
{
    public class BookGenreDto : ValidatableBindableBase
    {
        private Guid _bookGenrecode;
        public Guid BookGenrecode
        {
            get { return _bookGenrecode; }
            set
            {
                _bookGenrecode = value;
            }
        }

        private string _bookGenreName;

        public string BookGenreName
        {
            get { return _bookGenreName; }
            set
            {
                _bookGenreName = value;
                RaisePropertyChanged();
            }
        }
        public void ValidateBookGenreName()
        {
            ClearErrors(nameof(BookGenreName));
            if (string.IsNullOrEmpty(BookGenreName))
                AddError(nameof(BookGenreName), "Không được bỏ trống!");
            if (BookGenreName?.Length > 256)
                AddError(nameof(BookGenreName), "Vượt quá 256 ký tự!");
        }
    }
}