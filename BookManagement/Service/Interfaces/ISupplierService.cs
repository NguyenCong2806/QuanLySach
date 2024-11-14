using BookManagement.Data.Dto;
using BookManagement.Entity;

namespace BookManagement.Service.Interfaces
{
    public interface ISupplierService :
        IService<Supplier, SupplierDto>
    {
    }
}