using BookManagement.Data.Dto;
using BookManagement.Entity;
using BookManagement.Repositorys.Interfaces;
using BookManagement.Service.Interfaces;

namespace BookManagement.Service.Deployment
{
    public class SupplierService : Service<Supplier, SupplierDto>, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository) :
            base(supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
    }
}