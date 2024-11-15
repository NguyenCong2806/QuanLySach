using System;

namespace BookManagement.Data.Dto
{
    public class EmployeeDto : ValidatableBindableBase
    {
        private Guid _employeecode;

        public Guid Employeecode
        {
            get { return _employeecode; }
            set
            {
                _employeecode = value;
            }
        }

        private string _employeeName;

        public string EmployeeName
        {
            get { return _employeeName; }
            set
            {
                _employeeName = value;
                RaisePropertyChanged();
            }
        }
        private bool _sex;

        public bool Sex
        {
            get { return _sex; }
            set
            {
                _sex = value;
                RaisePropertyChanged();
            }
        }
        private string _position;

        public string Position
        {
            get { return _position; }
            set
            {
                _position = value;
                RaisePropertyChanged();
            }
        }
        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                RaisePropertyChanged();
            }
        }
        public void ValidateEmployeeName()
        {
            ClearErrors(nameof(EmployeeName));
            if (string.IsNullOrEmpty(EmployeeName))
                AddError(nameof(EmployeeName), "Không được bỏ trống!");
            if (EmployeeName?.Length > 256)
                AddError(nameof(EmployeeName), "Vượt quá 256 ký tự!");

            ClearErrors(nameof(Position));
            if (string.IsNullOrEmpty(Position))
                AddError(nameof(Position), "Không được bỏ trống!");
            if (Position?.Length > 256)
                AddError(nameof(Position), "Vượt quá 256 ký tự!");
        }
    }
}
