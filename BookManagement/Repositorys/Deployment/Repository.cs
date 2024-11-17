using BookManagement.Data;

using BookManagement.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace BookManagement.Repositorys.Deployment
{
    public abstract class Repository<T> : IRepositorys<T> where T : class
    {
        protected readonly DbContext _context;
        private DbSet<T> _table;

        protected Repository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                _table.Add(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    _table.Add(entity);
                }
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                _table.Remove(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var data = await GetValueAsync(predicate);
                _table.Remove(data);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task<ICollection<T>> GetAll()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task<ResultData<T>> GetAllAsync<Tkey>(PagedList<T, Tkey> pagedList)
        {
            ResultData<T> resultData = new ResultData<T>();
            try
            {
                resultData.ListData = _table;
                if (pagedList.KeyFind.Count() > 0)
                {
                    foreach (var item in pagedList.KeyFind)
                    {
                        resultData.ListData = _table.Where(item);
                    }
                }
                resultData.TotalCount = await resultData.ListData.CountAsync();

                double pageCount = (double)(resultData.TotalCount / Convert.ToDecimal(pagedList.RecordsPerPage));
                resultData.PageCount = (int)Math.Ceiling(pageCount);

                resultData.TotalPage = await _table.CountAsync();
                var res = await resultData.ListData.OrderByDescending(pagedList.KeySelector)
                                .Skip((pagedList.PageNumber - 1) * pagedList.RecordsPerPage)
                                .Take(pagedList.RecordsPerPage).ToListAsync();

                resultData.ListData = res.AsQueryable<T>();

                return resultData;
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task<T> GetValueAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _table.FirstOrDefaultAsync<T>(predicate);
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task<int> SaveAsync()
        {
            await _context.SaveChangesAsync();

            return (int)HttpStatusCode.OK;
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _table.AddOrUpdate(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task Dispose()
        {
            _context.Dispose();
            await Task.Yield();
        }
    }
}