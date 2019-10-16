using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Renting.Microservice.Domain
{
    public interface IQueryableUnitOfWork : IDisposable
    {
        DbSet<TEntity> GetSet<TEntity, TId>() where TId : struct where TEntity : Domain.Entities.EntityBase<TId>;
        void Commit();
        Task CommitAsync();
        DbContext GetContext();

    }
}
