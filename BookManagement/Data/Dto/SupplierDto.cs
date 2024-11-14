using System;

namespace BookManagement.Data.Dto
{
    public class SupplierDto : ValidatableBindableBase
    {
        private Guid _suppliercode;

        public Guid Suppliercode
        {
            get { return _suppliercode; }
            set
            {
                _suppliercode = value;
            }
        }

        private string _supplierName;

        public string SupplierName
        {
            get { return _supplierName; }
            set
            {
                _supplierName = value;
                RaisePropertyChanged();
            }
        }

        public void ValidateSupplierName()
        {
            ClearErrors(nameof(SupplierName));
            if (string.IsNullOrEmpty(SupplierName))
                AddError(nameof(SupplierName), "Không được bỏ trống!");
            if (SupplierName?.Length > 256)
                AddError(nameof(SupplierName), "Vượt quá 256 ký tự!");
        }
    }
}