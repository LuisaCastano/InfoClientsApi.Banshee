using InfoClients.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InfoClients.Api
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InfoClientsContext>
    {
        public InfoClientsContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<InfoClientsContext>();

            var connectionString = configuration.GetConnectionString("StringConnection");
            builder.UseSqlServer(connectionString,
                x => x.MigrationsHistoryTable("__MicroMigrationHistory",
                configuration.GetConnectionString("SchemaName")));
            return new InfoClientsContext(builder.Options, configuration.GetConnectionString("SchemaName"));
        }
    }
}
