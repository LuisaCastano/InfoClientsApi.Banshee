using InfoClients.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfoClients.Domain.IRepository
{
    public interface IERepository<TId, TEntity> : IDisposable where TId : struct where TEntity : EntityBase<TId>
    {
        IQueryableUnitOfWork UnitOfWork { get; }

        IEnumerable<TEntity> GetFromSql(string sql, params object[] parameters);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> invoiceBy = null, string includeProperties = "");

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "", bool track = false);
        IEnumerable<TEntity> GetAllWithOutTraking(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
          IOrderedQueryable<TEntity>> invoiceBy = null, string includeProperties = "");
        TEntity FindById(TId id);
        TEntity FindByCompositeKey(params object[] parameters);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(TId id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(TId id);
    }
}

