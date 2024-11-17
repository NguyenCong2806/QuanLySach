using BookManagement.Data.Dto;
using BookManagement.Entity;
using BookManagement.Repositorys.Interfaces;
using BookManagement.Service.Interfaces;

namespace BookManagement.Service.Deployment
{
    public class BookService: Service<Book, BookDto>, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository) :
            base(bookRepository)
        {
            _bookRepository = bookRepository;
        }
    }
}
