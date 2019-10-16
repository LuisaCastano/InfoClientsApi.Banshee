using InfoClients.Api.Filter;
using InfoClients.Core;
using InfoClients.Domain;
using InfoClients.Domain.IRepository;
using InfoClients.Domain.Repository;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using log4net;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using System.Reflection;

namespace InfoClients
{
    public class Startup
    {
        private static IContainer ApplicationContainer { get; set; }
        public IConfiguration Configuration { get; }
        public IConfiguration JsonConfig { get; set; }
        public IConfigurationRoot ConfigurationRoot { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfigurationRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            JsonConfig = ConfigurationRoot;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(CustomExceptionFilterAttribute));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "InfoClients",
                    Description = "Servicio Rest"
                });
                c.CustomSchemaIds(x => x.FullName);
            });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddDbContext<InfoClientsContext>(options =>
            options.UseSqlServer(JsonConfig.GetConnectionString("StringConnection"),
            x => x.MigrationsHistoryTable("__MicroMigrationHistory", JsonConfig.GetConnectionString("SchemaName"))));


            CreateDependencyInjection(services);

            return new AutofacServiceProvider(ApplicationContainer);
        }

        public void CreateDependencyInjection(IServiceCollection services)
        {
            // create a Autofac container builder
            ContainerBuilder builder = new ContainerBuilder();
            // read service collection to Autofac
            builder.Populate(services);
            var mapperConfiguration = new MapperConfiguration(configurationExpresion =>
            {
                configurationExpresion.AddProfile(new MappingProfile());
            });

            builder.Register(c => LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)).As<ILog>();
            builder.Register(componentContext => mapperConfiguration.CreateMapper()).As<IMapper>();
            builder.Register(c => ConfigurationRoot).As<IConfigurationRoot>();
            builder.RegisterType<InfoClientsContext>().As<IQueryableUnitOfWork>().WithParameter("schema", JsonConfig.GetConnectionString("SchemaName"));
            builder.RegisterType<CityRepository>().As<ICityRepository>();
            builder.RegisterType<ClientRepository>().As<IClientRepository>();
            builder.RegisterType<ClientVisitRepository>().As<IClientVisitRepository>();
            builder.RegisterType<CountryRepository>().As<ICountryRepository>();
            builder.RegisterType<StateRepository>().As<IStateRepository>();
            builder.RegisterType<SalesRepresentativeRepository>().As<ISalesRepresentativeRepository>();
            ApplicationContainer = builder.Build();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                // runs migrations for you!! 
                if (!serviceScope.ServiceProvider.GetService<IQueryableUnitOfWork>().AllMigrationsApplied())
                {
                    serviceScope.ServiceProvider.GetService<IQueryableUnitOfWork>().GetContext().Database.Migrate();
                }
                // Seed the db!!
                if (JsonConfig["isDebug"].Equals("True"))
                {
                    serviceScope.ServiceProvider.GetService<IQueryableUnitOfWork>().EnsureSeeded();
                }
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Configuration.GetSection("swaggerUrl").Value, "API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
