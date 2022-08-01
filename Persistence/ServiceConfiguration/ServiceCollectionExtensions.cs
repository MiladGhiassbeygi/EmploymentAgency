using Application.Contracts.Persistence;
using Application.Contracts.Persistence.Area;
using Application.Contracts.Persistence.JobContract;
using Application.Contracts.ReadPersistence;
using Application.Contracts.ReadPersistence.Area;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Persistence.ReadRepositories;
using Persistence.ReadRepositories.Area;
using Persistence.WriteRepositories;
using Persistence.WriteRepositories.Common;

namespace Persistence.ServiceConfiguration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICountryRepository,CountryRepository>();
            services.AddScoped<IReadCountryRepository,ReadCountryRepository>();
            
            services.AddScoped<IJobSeekerRepository, JobSeekerRepository>();
            services.AddScoped<IReadJobSeekerRepository,ReadJobSeekerRepository>();

            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IReadJobRepository,ReadJobRepository>();

            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase("EmploymentAgency");
            services.AddSingleton(mongoDatabase);
            
            services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options
                            .UseSqlServer(configuration.GetConnectionString("SqlServer"));
                    });

            return services;
        }
    }
}
