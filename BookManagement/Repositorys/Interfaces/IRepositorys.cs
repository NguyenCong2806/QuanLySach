using BookManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookManagement.Repositorys.Interfaces
{
    public interface IRepositorys<T> where T : class
    {
        Task<ResultData<T>> GetAllAsync<Tkey>(PagedList<T, Tkey> pagedList);

        Task<IQueryable<T>> GetAll();

        Task<T> GetValueAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);

        Task AddRange(IEnumerable<T> entities);

        Task<int> SaveAsync();

        Task Dispose();

        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        Task DeleteAsync(T entity);

        Task UpdateAsync(T entity);
    }
}