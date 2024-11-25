namespace BookManagement.Data.Dto
{
    public class UserLoginDto : ValidatableBindableBase
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged();
            }
        }
        private string _passWord;

        public string PassWord
        {
            get { return _passWord; }
            set
            {
                _passWord = value;
                RaisePropertyChanged();
            }
        }
        public void ValidateBookGenreName()
        {
            ClearErrors(nameof(UserName));
            ClearErrors(nameof(PassWord));

            if (string.IsNullOrEmpty(UserName))
                AddError(nameof(UserName), "Không được bỏ trống!");
            if (UserName?.Length > 256)
                AddError(nameof(PassWord), "Vượt quá 256 ký tự!");

            if (string.IsNullOrEmpty(PassWord))
                AddError(nameof(PassWord), "Không được bỏ trống!");
            if (PassWord?.Length > 256)
                AddError(nameof(PassWord), "Vượt quá 256 ký tự!");
        }
    }
}