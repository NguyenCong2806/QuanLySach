using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookManagement.Common;
using BookManagement.Data;
using BookManagement.Helpper.Config;
using BookManagement.Repositorys.Interfaces;
using BookManagement.Service.Interfaces;
using SweetAlertSharp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookManagement.Service.Deployment
{
    public class Service<TEntity, TModel> : IService<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
        protected IRepositorys<TEntity> _repositorys { get; set; }
        protected Mapper _mapper;

        public Service(IRepositorys<TEntity> repositorys)
        {
            _repositorys = repositorys;
            _mapper = MapperConfig<TEntity, TModel>.InitializeAutomapper();
        }

        public async Task AddAsync(TModel entity)
        {
            try
            {
                TEntity data = _mapper.Map<TEntity>(entity);
                await _repositorys.AddAsync(data);
                Extend.Notification(Notice.ADDSUCCESS, Notice.OFFSETX, Notice.OFFSETY, Notice.OK);
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task AddRange(IEnumerable<TModel> entities)
        {
            try
            {
                IEnumerable<TEntity> data = _mapper.Map<IEnumerable<TEntity>>(entities);
                await _repositorys.AddRange(data);
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task DeleteAsync(TModel entity)
        {
            try
            {
                if (Extend.SweetAlertResults(Notice.ALERTCAPTION, Notice.ALERTMESSAGE, Notice.OKTEXT, Notice.CANCELTEXT, SweetAlertButton.OKCancel))
                {
                    TEntity data = _mapper.Map<TEntity>(entity);
                    await _repositorys.DeleteAsync(data);
                    Extend.Notification(Notice.DELETESUCCESS, Notice.OFFSETX, Notice.OFFSETY, Notice.OK);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task<IQueryable<TModel>> GetAll()
        {
            try
            {
                var configuration = new MapperConfiguration(cfg => cfg.CreateMap<TEntity, TModel>());
                var data = await _repositorys.GetAll();
                var model = data.AsQueryable<TEntity>().ProjectTo<TModel>(configuration);
                return model;
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task UpdateAsync(TModel entity)
        {
            try
            {
                TEntity data = _mapper.Map<TEntity>(entity);
                await _repositorys.UpdateAsync(data);
                Extend.Notification(Notice.EDITSUCCESS, Notice.OFFSETX, Notice.OFFSETY, Notice.OK);
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task<ResultData<TModel>> GetAllAsync<Tkey>(PagedList<TEntity, Tkey> pagedList)
        {
            try
            {
                var configuration = new MapperConfiguration(cfg => cfg.CreateMap<TEntity, TModel>());

                ResultData<TModel> resultData = new ResultData<TModel>();

                var data = await _repositorys.GetAllAsync(pagedList);

                resultData.TotalPage = data.TotalPage;
                resultData.TotalCount = data.TotalCount;
                resultData.PageCount = data.PageCount;
                resultData.ListData = data.ListData.ProjectTo<TModel>(configuration);

                return resultData;
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task<TModel> GetValueAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var data = await _repositorys.GetValueAsync(predicate);
                return _mapper.Map<TModel>(data);
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                if (Extend.SweetAlertResults(Notice.ALERTCAPTION, Notice.ALERTMESSAGE, Notice.OKTEXT, Notice.CANCELTEXT, SweetAlertButton.OKCancel))
                {
                    await _repositorys.DeleteAsync(predicate);
                    Extend.Notification(Notice.DELETESUCCESS, Notice.OFFSETX, Notice.OFFSETY, Notice.OK);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }
    }
}