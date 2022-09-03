using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.ReadPersistence;
using Application.Contracts.WritePersistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace Application.BackgroundWorker
{
    public class AddDeleteEmployerAcivityFieldWorker : BackgroundService
    {
        private readonly ChannelQueue<EmployerAcivityFieldDeleted> _readModelChannel;
        private readonly ILogger<AddDeleteEmployerAcivityFieldWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddDeleteEmployerAcivityFieldWorker(ChannelQueue<EmployerAcivityFieldDeleted> readModelChannel, ILogger<AddDeleteEmployerAcivityFieldWorker> logger, IServiceProvider serviceProvider)
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

                var writeRepository = scope.ServiceProvider.GetRequiredService<IEmployerAcivityFieldRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadEmployerActivitiesRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var employerAcivityField = await writeRepository.GetEmployerAcivityFieldByIdAsync(item.EmployerAcivityFieldId);

                        if (employerAcivityField != null)
                        {
                            await readRepository.DeleteAsync(x => x.EmployerAcivityFieldId == item.EmployerAcivityFieldId, stoppingToken);
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
