using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.ReadPersistence;
using Application.Contracts.WritePersistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker.AddDeleteEmployer
{
   
    public class AddDeleteEmployerWorker : BackgroundService
    {
        private readonly ChannelQueue<EmployerDeleted> _readModelChannel;
        private readonly ILogger<AddDeleteEmployerWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddDeleteEmployerWorker(ChannelQueue<EmployerDeleted> readModelChannel, ILogger<AddDeleteEmployerWorker> logger, IServiceProvider serviceProvider)
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
                            await readRepository.DeleteAsync(x=> x.EmployerId == item.EmployerId,stoppingToken);
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
