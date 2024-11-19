using BookManagement.Data.Dto;
using BookManagement.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace BookManagement.Service.Interfaces
{
    public interface IBookService: IService<Book, BookDto>
    {
       Task DeleteBookAsync(Expression<Func<Book, bool>> predicate);
    }
}
