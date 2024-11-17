using BookManagement.Entity;
using BookManagement.Repositorys.Interfaces;
using System.Data.Entity;

namespace BookManagement.Repositorys.Deployment
{
    public class BookRepository: Repository<Book>, IBookRepository
    {
        public BookRepository(DbContext _context) : base(_context)
        {

        }
    }
}
