using Domain.ReadModel;
using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence.Area;
using Application.Contracts.ReadPersistence.Area;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace Application.BackgroundWorker.AddReadMovie
{
    public class AddReadModelWorker : BackgroundService
    {
        private readonly ChannelQueue<CountryAdded> _readModelChannel;
        private readonly ILogger<AddReadModelWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddReadModelWorker(ChannelQueue<CountryAdded> readModelChannel, ILogger<AddReadModelWorker> logger, IServiceProvider serviceProvider)
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

                var writeRepository = scope.ServiceProvider.GetRequiredService<ICountryRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadCountryRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var country = await writeRepository.GetCountryByIdAsync(item.CountryId);

                        if (country != null)
                        {
                            await readRepository.AddAsync(new Country
                            {
                                CountryId = country.Id,
                                AreaCode = country.AreaCode,
                                PostalCode = country.PostalCode,
                                Title = country.Title
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