using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker.AddUpdateEmployer
{
    public class AddUpdateEmployerCommissionWorker : BackgroundService
    {
        private readonly ChannelQueue<EmployerCommisionUpdated> _readModelChannel;
        private readonly ILogger<AddUpdateEmployerCommissionWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddUpdateEmployerCommissionWorker(ChannelQueue<EmployerCommisionUpdated> readModelChannel, ILogger<AddUpdateEmployerCommissionWorker> logger, IServiceProvider serviceProvider)
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
                        var employerCommission = await writeRepository.GetEmployerCommissionByIdAsync(item.EmployerCommisionId);

                        if (employerCommission != null)
                        {
                            var mongoEmployerCommission = new EmployerCommission
                            {
                                EmployerCommissionId = employerCommission.Id,
                                EmployerId = employerCommission.EmployerId,
                                IsFixed = employerCommission.IsFixed,
                                Value = employerCommission.Value
                            };

                            await readRepository.UpdateAsync(mongoEmployerCommission, x => x.EmployerCommissionId == item.EmployerCommisionId, stoppingToken);
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
