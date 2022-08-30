using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence.Area;
using Application.Contracts.ReadPersistence.Area;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker
{
    public class AddDeleteCountryWorker : BackgroundService
    {
        private readonly ChannelQueue<CountryDeleted> _readModelChannel;
        private readonly ILogger<AddDeleteCountryWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddDeleteCountryWorker(ChannelQueue<CountryDeleted> readModelChannel, ILogger<AddDeleteCountryWorker> logger, IServiceProvider serviceProvider)
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
                            await readRepository.DeleteAsync(x => x.CountryId == item.CountryId, stoppingToken);
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
