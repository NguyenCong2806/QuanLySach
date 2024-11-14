using BookManagement.Entity;
using BookManagement.Repositorys.Interfaces;
using System.Data.Entity;

namespace BookManagement.Repositorys.Deployment
{
    public class BookPublisherRepository: Repository<BookPublisher>, 
                                        IBookPublisherRepository
    {
        public BookPublisherRepository(DbContext _context) : base(_context)
        {

        }
    }
}