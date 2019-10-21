using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using InfoClients.Core.Interfaces;
using InfoClients.Domain.Entities;
using InfoClients.Domain.IRepository;

namespace InfoClients.Core.Services
{
    public class Service<TId, TEntity, TEntityDto> : IService<TId, TEntity, TEntityDto>
        where TId : struct
        where TEntityDto : EntityBase<TId>
        where TEntity : Domain.Entities.EntityBase<TId>
    {
        private readonly IERepository<TId, TEntity> repository;
        protected readonly IMapper serviceMapper;

        public Service(IERepository<TId, TEntity> repository, IMapper serviceMapper)
        {
            this.repository = repository;
            this.serviceMapper = serviceMapper;
        }

        public IERepository<TId, TEntity> GetRepository()
        {
            return this.repository;
        }

        public virtual async Task AddAsync(TEntityDto entity)
        {
            await repository.AddAsync(serviceMapper.Map<TEntity>(entity)).ConfigureAwait(false);
        }

        public virtual async Task DeleteAsync(TEntityDto entity)
        {
            await repository.DeleteAsync(serviceMapper.Map<TEntity>(entity)).ConfigureAwait(false);
        }

        public virtual async Task DeleteAsync(TId entityId)
        {
            TEntity entity = repository.FindById(entityId);
            await repository.DeleteAsync(entity).ConfigureAwait(false);
        }

        public virtual async Task UpdateAsync(TEntityDto entity)
        {
            await repository.UpdateAsync(serviceMapper.Map<TEntity>(entity)).ConfigureAwait(false);
        }

        public virtual IEnumerable<TEntityDto> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return from item in repository.GetAll(filter, orderBy, includeProperties)
                   select serviceMapper.Map<TEntityDto>(item);
        }

        public async Task<IEnumerable<TEntityDto>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
    string includeProperties = "", bool track = false)
        {
                return serviceMapper.Map<IEnumerable<TEntityDto>>(await repository.GetAllAsync(filter, orderBy, includeProperties).ConfigureAwait(false));

        }

        public virtual IEnumerable<TEntityDto> GetAllWithOutTraking(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return from item in repository.GetAllWithOutTraking(filter, orderBy, includeProperties)
                   select serviceMapper.Map<TEntityDto>(item);
        }

        public virtual TEntityDto FindById(TId id)
        {
            TEntity book = repository.FindById(id);
            return book != null ? serviceMapper.Map<TEntityDto>(book) : null;
        }

        public virtual TEntityDto FindByCompositeKey(params object[] parameters)
        {
            TEntity book = repository.FindByCompositeKey(parameters);
            return book != null ? serviceMapper.Map<TEntityDto>(book) : null;
        }

        public virtual void Add(TEntityDto entity)
        {
            repository.Add(serviceMapper.Map<TEntity>(entity));
        }

        public virtual void Update(TEntityDto entity)
        {
            repository.Update(serviceMapper.Map<TEntity>(entity));
        }

        public virtual void Delete(TEntityDto entity)
        {
            repository.Delete(serviceMapper.Map<TEntity>(entity));
        }

        public virtual void Delete(TId entityId)
        {
            TEntity entity = repository.FindById(entityId);
            repository.Delete(entity);
        }

        public virtual async Task<IEnumerable<TEntityDto>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return from item in await repository.GetAllAsync(filter, orderBy, includeProperties).ConfigureAwait(false)
                   select serviceMapper.Map<TEntityDto>(item);
        }
    }
}
