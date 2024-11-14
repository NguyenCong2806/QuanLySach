using BookManagement.Entity;
using BookManagement.Repositorys.Interfaces;
using System.Data.Entity;

namespace BookManagement.Repositorys.Deployment
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(DbContext _context) : base(_context)
        {
        }
    }
}