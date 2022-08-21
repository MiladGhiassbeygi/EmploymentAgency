using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Contracts.Persistence.Area;
using Application.Contracts.Persistence.JobContract;
using Application.Contracts.ReadPersistence;
using Application.Contracts.ReadPersistence.Account;
using Application.Contracts.ReadPersistence.Area;
using Application.Contracts.ReadPersistence.ReadWorkExperience;
using Application.Contracts.WritePersistence;
using Application.Contracts.WritePersistence.Reminder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Persistence.ReadRepositories;
using Persistence.ReadRepositories.Account;
using Persistence.ReadRepositories.Area;
using Persistence.ReadRepositories.ReadWorkExperience;
using Persistence.WriteRepositories;
using Persistence.WriteRepositories.Common;
using Persistence.WriteRepositories.Reminder;

namespace Persistence.ServiceConfiguration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IReadAccountRepository, ReadAccountRepository>();

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IReadCountryRepository, ReadCountryRepository>();

            services.AddScoped<IJobSeekerRepository, JobSeekerRepository>();
            services.AddScoped<IReadJobSeekerRepository, ReadJobSeekerRepository>();

            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IReadJobRepository, ReadJobRepository>();

            services.AddScoped<IEmployerRepository, EmployerRepository>();
            services.AddScoped<IReadEmployerRepository, ReadEmployerRepository>();

            services.AddScoped<IEmployerAcivityFieldRepository, EmployerAcivityFieldRepository>();
            services.AddScoped<IReadEmployerActivitiesRepository, ReadEmployerActivitiesRepository>();

            services.AddScoped<IReminderRepository, ReminderRepository>();
            services.AddScoped<IReadReminderRepository, ReadReminderRepository>();

            services.AddScoped<IWorkExperienceRepository, WorkExperienceRepository>();
            services.AddScoped<IReadWorkExperienceRepository, ReadWorkExperienceRepository>();

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
