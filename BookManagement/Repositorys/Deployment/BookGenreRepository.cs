using BookManagement.Entity;
using BookManagement.Repositorys.Interfaces;
using System.Data.Entity;

namespace BookManagement.Repositorys.Deployment
{
    public class BookGenreRepository : Repository<BookGenre>, IBookGenreRepository
    {
        public BookGenreRepository(DbContext _context): base(_context)
        {
            
        }
    }
}