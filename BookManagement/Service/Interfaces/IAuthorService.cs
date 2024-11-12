using BookManagement.Data.Dto;
using BookManagement.Entity;

namespace BookManagement.Service.Interfaces
{
    public interface IAuthorService : IService<Author, AuthorDto>
    {
    }
}