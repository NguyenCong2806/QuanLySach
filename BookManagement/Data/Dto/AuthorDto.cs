using System;

namespace BookManagement.Data.Dto
{
    public class AuthorDto : ValidatableBindableBase
    {
        private Guid _authorcode;

        public Guid Authorcode
        {
            get { return _authorcode; }
            set
            {
                _authorcode = value;
            }
        }

        private string _authorName;

        public string AuthorName
        {
            get { return _authorName; }
            set
            {
                _authorName = value;
                RaisePropertyChanged();
            }
        }

        public void ValidateBookGenreName()
        {
            ClearErrors(nameof(AuthorName));
            if (string.IsNullOrEmpty(AuthorName))
                AddError(nameof(AuthorName), "Không được bỏ trống!");
            if (AuthorName?.Length > 256)
                AddError(nameof(AuthorName), "Vượt quá 256 ký tự!");
        }
    }
}