using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.ReadPersistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker.AddDeleteEmployer
{
   
    public class AddDeleteEmployerCommissionWorker : BackgroundService
    {
        private readonly ChannelQueue<EmployerCommisionDeleted> _readModelChannel;
        private readonly ILogger<AddDeleteEmployerCommissionWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddDeleteEmployerCommissionWorker(ChannelQueue<EmployerCommisionDeleted> readModelChannel, ILogger<AddDeleteEmployerCommissionWorker> logger, IServiceProvider serviceProvider)
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

                var writeRepository = scope.ServiceProvider.GetRequiredService<IEmployerCommissionRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadEmployerCommissionRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var employer = await writeRepository.GetEmployerCommissionByIdAsync(item.EmployerCommisionId);

                        if (employer != null)
                        {
                            await readRepository.DeleteAsync(x=> x.EmployerCommissionId == item.EmployerCommisionId,stoppingToken);
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
