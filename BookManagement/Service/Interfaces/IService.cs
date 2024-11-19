using BookManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookManagement.Service.Interfaces
{
    public interface IService<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
        Task<ResultData<TModel>> GetAllAsync<Tkey>(PagedList<TEntity, Tkey> pagedList);

        Task<IQueryable<TModel>> GetAll();

        Task<TModel> GetValueAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TModel entity);

        Task AddRange(IEnumerable<TModel> entities);

        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);


        Task DeleteAsync(TModel entity);

        Task UpdateAsync(TModel entity);
    }
}