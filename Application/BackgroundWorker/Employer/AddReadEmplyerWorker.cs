using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.ReadPersistence;
using Application.Contracts.WritePersistence;
using Domain.ReadModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker.AddReadEmployer
{
    public class AddReadEmplyerWorker : BackgroundService
    {
        private readonly ChannelQueue<EmployerAdded> _readModelChannel;
        private readonly ILogger<AddReadEmplyerWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddReadEmplyerWorker(ChannelQueue<EmployerAdded> readModelChannel, ILogger<AddReadEmplyerWorker> logger, IServiceProvider serviceProvider)
        {
            _readModelChannel = readModelChannel;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var writeRepository = scope.ServiceProvider.GetRequiredService<IEmployerRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadEmployerRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var employer = await writeRepository.GetEmployerByIdAsync(item.EmployerId);

                        if (employer != null)
                        {
                            await readRepository.AddAsync(new Employer
                            {
                                EmployerId = employer.Id,
                                FirstName = employer.FirstName,
                                LastName = employer.LastName,
                                Address = employer.Address,
                                PhoneNumber = employer.PhoneNumber,
                                Email = employer.Email,
                                WebsiteLink = employer.WebsiteLink,
                                NecessaryExplanation = employer.NecessaryExplanation,
                                FieldOfActivityId = employer.FieldOfActivityId,
                                IsFixed = employer.IsFixed,
                                ExactAmountRecived = employer.ExactAmountRecived,
                                DefinerId = employer.DefinerId
                                
                            }, stoppingToken);
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }
            }
        }
    }
}
