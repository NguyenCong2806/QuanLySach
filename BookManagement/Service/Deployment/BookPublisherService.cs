using BookManagement.Data.Dto;
using BookManagement.Entity;
using BookManagement.Repositorys.Interfaces;
using BookManagement.Service.Interfaces;

namespace BookManagement.Service.Deployment
{
    public class BookPublisherService : Service<BookPublisher, BookPublisherDto>,
        IBookPublisherService
    {
        private readonly IBookPublisherRepository _bookPublisherRepository;

        public BookPublisherService(IBookPublisherRepository bookPublisherRepository) : 
            base(bookPublisherRepository)
        {
            _bookPublisherRepository = bookPublisherRepository;
        }
    }
}