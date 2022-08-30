using System.Diagnostics;
using Application.BackgroundWorker;
using Application.BackgroundWorker.Account;
using Application.BackgroundWorker.AddDeleteEmployer;
using Application.BackgroundWorker.AddReadCountry;
using Application.BackgroundWorker.AddReadEmployer;
using Application.BackgroundWorker.AddReadEmployerActivity;
using Application.BackgroundWorker.AddReadJobSeeker;
using Application.BackgroundWorker.AddUpdateEmployer;
using Application.BackgroundWorker.AddUpdateJobSeeker;
using Application.BackgroundWorker.AddDeleteJobSeeker;
using Application.BackgroundWorker.Reminder;
using Application.Common.BaseChannel;
using Application.ServiceConfiguration;
using Domain.WriteModel.User;
using Identity.Identity.Dtos;
using Identity.Identity.SeedDatabaseService;
using Identity.Jwt;
using Identity.ServiceConfiguration;
using InfrastructureServices.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence;
using Persistence.ServiceConfiguration;
using Serilog;
using Web.Api.Controllers.V1;
using WebFramework.Filters;
using WebFramework.ServiceConfiguration;
using WebFramework.Swagger;
using Application.BackgroundWorker.AddUpdateJob;
using Application.BackgroundWorker.AddUpdateEducationalBackground;
using Application.BackgroundWorker.AddDeleteJob;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder= WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy
                          .AllowAnyHeader()
                          .AllowAnyOrigin()
                          .AllowAnyMethod()
                          ;
                      });
});

builder.Host.UseSerilog(LoggingConfiguration.ConfigureLogger);

var configuration = builder.Configuration;

Activity.DefaultIdFormat = ActivityIdFormat.W3C;

builder.Services.Configure<IdentitySettings>(configuration.GetSection(nameof(IdentitySettings)));

var identitySettings = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>(); 

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(OkResultAttribute));
    options.Filters.Add(typeof(NotFoundResultAttribute));
    options.Filters.Add(typeof(ContentResultFilterAttribute));
    options.Filters.Add(typeof(ModelStateValidationAttribute));
    options.Filters.Add(typeof(BadRequestResultFilterAttribute));

}).ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });
//.AddFluentValidation(cfg => { cfg.RegisterValidatorsFromAssemblyContaining<UserCreateCommand>(); }); //Uncomment for FluentValidation in Application Layer

builder.Services.AddSwagger();



#region Channel Singletion Injection 

builder.Services.AddSingleton(typeof(ChannelQueue<>));

builder.Services.AddHostedService<AddReadCountryWorker>();
builder.Services.AddHostedService<AddUpdateCountryWorker>();
builder.Services.AddHostedService<AddDeleteCountryWorker>();
builder.Services.AddHostedService<AddReadAccountWorker>();

builder.Services.AddHostedService<AddReadSkillWorker>();
builder.Services.AddHostedService<AddUpdateSkillWorker>();
builder.Services.AddHostedService<AddDeleteSkillWorker>();

builder.Services.AddHostedService<AddReadJobSeekerWorker>();
builder.Services.AddHostedService<AddUpdateJobSeekerWorker>();
builder.Services.AddHostedService<AddDeleteJobSeekerWorker>();

builder.Services.AddHostedService<AddReadJobWorker>();
builder.Services.AddHostedService<AddUpdateJobWorker>();
builder.Services.AddHostedService<AddDeleteJobWorker>();
builder.Services.AddHostedService<AddReadJobEssentialSkillsWorker>();
builder.Services.AddHostedService<AddReadJobUnnessecarySkillsWorker>();
builder.Services.AddHostedService<AddReadEmployerAcivityFieldWorker>();

builder.Services.AddHostedService<AddReadWorkExperienceWorker>();

builder.Services.AddHostedService<AddReadReminderWorker>();

builder.Services.AddHostedService<AddReadEmplyerCommisionWorker>();
builder.Services.AddHostedService<AddDeleteEmployerCommissionWorker>();
builder.Services.AddHostedService<AddUpdateEmployerCommissionWorker>();
builder.Services.AddHostedService<AddReadEmployerAcivityFieldWorker>();

builder.Services.AddHostedService<AddReadEmplyerWorker>();
builder.Services.AddHostedService<AddDeleteEmployerWorker>();
builder.Services.AddHostedService<AddUpdateEmployerWorker>();

builder.Services.AddHostedService<AddReadEducationalBackgroundWorker>();
builder.Services.AddHostedService<AddUpdateEducationalBackgroundWorker>();
builder.Services.AddHostedService<AddDeleteEducationalBackgroundWorker>();

builder.Services.AddHostedService<AddReadSuccessedContractWorker>();


#endregion



builder.Services.AddApplicationServices().RegisterIdentityServices(identitySettings)
    .AddPersistenceServices(configuration).AddWebFrameworkServices();

var app = builder.Build();


#region Seeding and creating database

await using (var scope = app.Services.CreateAsyncScope())
{
    var context=scope.ServiceProvider.GetService<ApplicationDbContext>();

    if (context is null)
        throw new Exception("Database Context Not Found");

    if (!((RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>()).Exists())
    {
        await context.Database.MigrateAsync();
    }

    var seedService = scope.ServiceProvider.GetRequiredService<ISeedDataBase>();
    await seedService.Seed();
}

#endregion

#region Pipleline Configuration

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwaggerAndUI();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.RunAsync();
#endregion


