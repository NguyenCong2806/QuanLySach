using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
                AddError(nameof(BookGenreName), "Username cannot be empty.");
            if (string.Equals(BookGenreName, "Admin", StringComparison.OrdinalIgnoreCase))
                AddError(nameof(BookGenreName), "Admin is not valid username.");
            if (BookGenreName == null || BookGenreName?.Length <= 5)
                AddError(nameof(BookGenreName), "Username must be at least 6 characters long.");
        }
    }
}