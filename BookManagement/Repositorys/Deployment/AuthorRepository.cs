using BookManagement.Entity;
using BookManagement.Repositorys.Interfaces;
using System.Data.Entity;

namespace BookManagement.Repositorys.Deployment
{
    public class AuthorRepository: Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(DbContext _context): base(_context)
        {
            
        }
    }
}