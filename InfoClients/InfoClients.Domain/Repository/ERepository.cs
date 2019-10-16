using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InfoClients.Domain.Entities;
using InfoClients.Domain.IRepository;

namespace InfoClients.Domain.Repository
{
    public class ERepository<TId, TEntity> : IERepository<TId, TEntity> where TId : struct where TEntity : EntityBase<TId>
    {
        private readonly IQueryableUnitOfWork unitOfWork;

        public ERepository(IQueryableUnitOfWork masterContext)
        {
            unitOfWork = masterContext;
        }

        public IQueryableUnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> invoiceBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = unitOfWork.GetSet<TEntity, TId>();
            return GetAllResponseQuery(filter, invoiceBy, includeProperties, ref query);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
    string includeProperties = "",
    bool track = false)
        {
            IQueryable<TEntity> query = (!track) ? UnitOfWork.GetSet<TEntity, TId>().AsNoTracking() : UnitOfWork.GetSet<TEntity, TId>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync().ConfigureAwait(false);
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<TEntity> GetAllWithOutTraking(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> invoiceBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = unitOfWork.GetSet<TEntity, TId>().AsNoTracking();
            return GetAllResponseQuery(filter, invoiceBy, includeProperties, ref query);
        }

        private static IEnumerable<TEntity> GetAllResponseQuery(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> invoiceBy, string includeProperties, ref IQueryable<TEntity> query)
        {
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return (invoiceBy != null) ? invoiceBy(query).ToList() : query.ToList();
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity != null)
            {
                var item = unitOfWork.GetSet<TEntity, TId>();
                item.Add(entity);
                await unitOfWork.CommitAsync().ConfigureAwait(false);
            }
        }
        public async Task UpdateAsync(TEntity entity)
        {
            if (entity != null)
            {
                var book = unitOfWork.GetSet<TEntity, TId>();
                book.Update(entity);
                await unitOfWork.CommitAsync().ConfigureAwait(false);
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity != null)
            {
                unitOfWork.GetSet<TEntity, TId>().Remove(entity);
                await unitOfWork.CommitAsync().ConfigureAwait(false);
            }
        }
        public async Task DeleteAsync(TId id)
        {
            var address = FindById(id);
            if (address != null)
            {
                await DeleteAsync(address).ConfigureAwait(false);
            }
        }
        public async Task BulkInsertAsync(IEnumerable<TEntity> entity)
        {
            if (entity != null && entity.Any())
            {
                unitOfWork.GetSet<TEntity, TId>().AddRange(entity);
                await unitOfWork.CommitAsync().ConfigureAwait(false);
            }
        }
        public async Task BulkUpsertAsync(IEnumerable<TEntity> entity)
        {

            if (entity != null && entity.Any())
            {
                foreach (var item in entity)
                {
                    unitOfWork.GetSet<TEntity, TId>().UpdateRange(entity);
                }

                await unitOfWork.CommitAsync().ConfigureAwait(false);
            }

        }
        public IEnumerable<TEntity> GetAll()
        {
            return unitOfWork.GetSet<TEntity, TId>();
        }
        public IEnumerable<TEntity> GetFromSql(string sql, params object[] parameters)
        {
            return unitOfWork.GetSet<TEntity, TId>().FromSql(sql, parameters);
        }
        public TEntity FindById(TId id)
        {
            return this.unitOfWork.GetSet<TEntity, TId>().Find(id);
        }

        public TEntity FindByCompositeKey(params object[] parameters)
        {
            return this.unitOfWork.GetSet<TEntity, TId>().Find(parameters);
        }

        public void Add(TEntity entity)
        {
            if (entity != null)
            {
                var item = unitOfWork.GetSet<TEntity, TId>();
                item.Add(entity);
                unitOfWork.Commit();
            }
        }
        public void Update(TEntity entity)
        {
            if (entity != null)
            {
                var item = unitOfWork.GetSet<TEntity, TId>();
                item.Update(entity);
                unitOfWork.Commit();
            }
        }
        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                unitOfWork.GetSet<TEntity, TId>().Remove(entity);
                unitOfWork.Commit();
            }
        }
        public void Delete(TId id)
        {
            var item = FindById(id);
            if (item != null)
            {
                Delete(item);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.unitOfWork.Dispose();
        }

    }
}
