﻿using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.ReadPersistence;
using Application.Contracts.WritePersistence;
using Domain.ReadModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace Application.BackgroundWorker
{
    public class AddUpdateEmployerAcivityFieldWorker : BackgroundService
    {
        private readonly ChannelQueue<EmployerActivityFieldUpdated> _readModelChannel;
        private readonly ILogger<AddUpdateEmployerAcivityFieldWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddUpdateEmployerAcivityFieldWorker(ChannelQueue<EmployerActivityFieldUpdated> readModelChannel, ILogger<AddUpdateEmployerAcivityFieldWorker> logger, IServiceProvider serviceProvider)
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
                        var employerAcivityField = await writeRepository.GetEmployerAcivityFieldByIdAsync(item.EmployerActivityFieldId);

                        if (employerAcivityField != null)
                        {
                            var mongoEmployerAcivityField = new EmployerAcivityField
                            {
                                EmployerAcivityFieldId = employerAcivityField.Id,
                                Title = employerAcivityField.Title
                            };

                            await readRepository.UpdateAsync(mongoEmployerAcivityField, x => x.EmployerAcivityFieldId == item.EmployerActivityFieldId , stoppingToken);
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
