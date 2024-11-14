using BookManagement.Data;
using BookManagement.Data.Dto;
using System.Collections.ObjectModel;

namespace BookManagement.Model
{
    public class SupplierModel : DataModel<SupplierDto>
    {
        public SupplierModel()
        {
            Model = new SupplierDto();
            Models = new ObservableCollection<SupplierDto>();
        }
    }
}