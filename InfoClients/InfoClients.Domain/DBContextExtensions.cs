using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;

namespace InfoClients.Domain
{
    public static class DBContextExtensions
    {
        public static bool AllMigrationsApplied(this IQueryableUnitOfWork context)
        {
            var applied = context.GetContext().GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetContext().GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);
            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this IQueryableUnitOfWork context)
        {
        }
    }
}
