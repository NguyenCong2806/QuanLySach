using BookManagement.Data.Dto;
using BookManagement.Entity;

namespace BookManagement.Service.Interfaces
{
    public interface IBookService: IService<Book, BookDto>
    {
    }
}
