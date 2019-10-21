using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace InfoClients.Domain
{
    public class InfoClientsContext : DbContext, IQueryableUnitOfWork
    {
        private readonly string Schema;
        public InfoClientsContext(DbContextOptions<InfoClientsContext> options, string schema) : base(options)
        {
            Schema = schema;

        }

        public DbContext GetContext()
        {
            return this;
        }

        public DbSet<TEntity> GetSet<TEntity, TId>() where TId : struct where TEntity : Domain.Entities.EntityBase<TId>
        {
            return Set<TEntity>();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.Entity<Entities.City>().ToTable("City");
            modelBuilder.Entity<Entities.Client>().ToTable("Client");
            modelBuilder.Entity<Entities.ClientVisit>().ToTable("ClientVisit");
            modelBuilder.Entity<Entities.Country>().ToTable("Country");
            modelBuilder.Entity<Entities.State>().ToTable("State");
            modelBuilder.Entity<Entities.SalesRepresentative>().ToTable("SalesRepresentative");
            base.OnModelCreating(modelBuilder);
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
            }

        }

        public async Task CommitAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
            }

        }
    }
}
