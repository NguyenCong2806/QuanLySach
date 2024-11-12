using BookManagement.Data.Dto;
using BookManagement.Entity;
using BookManagement.Repositorys.Interfaces;
using BookManagement.Service.Interfaces;

namespace BookManagement.Service.Deployment
{
    public class BookGenreService : Service<BookGenre, BookGenreDto>, IBookGenreService
    {
        private readonly IBookGenreRepository _bookGenreRepository;

        public BookGenreService(IBookGenreRepository bookGenreRepository) : base(bookGenreRepository)
        {
            _bookGenreRepository = bookGenreRepository;
        }
    }
}