using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence.Area;
using Application.Contracts.ReadPersistence.Area;
using Domain.ReadModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker
{
    public class AddUpdateCountryWorker : BackgroundService
    {
        private readonly ChannelQueue<CountryUpdated> _readModelChannel;
        private readonly ILogger<AddUpdateCountryWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddUpdateCountryWorker(ChannelQueue<CountryUpdated> readModelChannel, ILogger<AddUpdateCountryWorker> logger, IServiceProvider serviceProvider)
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
                            var mongoEmployer = new Country
                            {
                                CountryId = country.Id,
                                Title = country.Title,
                                PostalCode = country.PostalCode,
                                AreaCode = country.AreaCode,
                            };

                            await readRepository.UpdateAsync(mongoEmployer, x => x.CountryId == item.CountryId, stoppingToken);
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
