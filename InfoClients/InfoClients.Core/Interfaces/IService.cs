using InfoClients.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfoClients.Core.Interfaces
{
    public interface IService<TId, TEntity, TEntityDto> where TId : struct where TEntityDto : EntityBase<TId>
    {

        IEnumerable<TEntityDto> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<IEnumerable<TEntityDto>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
        IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        IEnumerable<TEntityDto> GetAllWithOutTraking(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        TEntityDto FindById(TId id);
        TEntityDto FindByCompositeKey(params object[] parameters);

        Task AddAsync(TEntityDto entity);
        Task UpdateAsync(TEntityDto entity);
        Task DeleteAsync(TEntityDto entity);
        Task DeleteAsync(TId entityId);
        void Add(TEntityDto entity);
        void Update(TEntityDto entity);
        void Delete(TEntityDto entity);
        void Delete(TId entityId);
    }
}
