using BookManagement.Data.Dto;
using BookManagement.Entity;
using BookManagement.Repositorys.Interfaces;
using BookManagement.Service.Interfaces;

namespace BookManagement.Service.Deployment
{
    public class AuthorService : Service<Author, AuthorDto>, IAuthorService
    {
        private readonly IAuthorRepository _AuthorRepository;

        public AuthorService(IAuthorRepository AuthorRepository) : base(AuthorRepository)
        {
            _AuthorRepository = AuthorRepository;
        }
    }
}