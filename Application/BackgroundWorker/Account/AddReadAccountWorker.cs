using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Identity;
using Application.Contracts.ReadPersistence.Account;
using Application.Contracts.ReadPersistence.Area;
using Domain.WriteModel.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BackgroundWorker.Account
{
    public class AddReadAccountWorker : BackgroundService
    {
        private readonly ChannelQueue<AccountAdded> _readModelChannel;
        private readonly ILogger<AddReadAccountWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddReadAccountWorker(ChannelQueue<AccountAdded> readModelChannel, ILogger<AddReadAccountWorker> logger, IServiceProvider serviceProvider)
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

                var writeRepository = scope.ServiceProvider.GetRequiredService<IAppUserManager>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadAccountRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var user = await writeRepository.GetByUserId(item.AccountId);

                        if (user != null)
                        {
                            await readRepository.AddAsync(new Domain.ReadModel.User
                            {
                               UserId = user.Id,
                               Email = user.Email,
                               Name = user.Name,
                               PhoneNumber = user.PhoneNumber,
                               UserName = user.UserName

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
