using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Persistence.WriteRepositories.Common;

namespace Persistence.ServiceConfiguration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region RegisterAllServicesDynamically

            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
              .Where(x => !x.IsInterface && !x.IsAbstract && x.Name.Contains("Repository")
                && (x.Namespace.Equals("Persistence.WriteRepositories")
                    || x.Namespace.Equals("Persistence.ReadRepositories")))
              .Select(s => new { Service = s.GetInterface($"I{s.Name}"), Implementation = s })
              .ToList();

            foreach (var type in types)
            {
                services.AddScoped(type.Service, type.Implementation);

            }

            #endregion

            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase("EmploymentAgency");
            services.AddSingleton(mongoDatabase);

            services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options
                            .UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
                    });

            return services;
        }
    }
}
