using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker
{
    public class AddUpdateJobWorker : BackgroundService
    {
        private readonly ChannelQueue<JobUpdated> _readModelChannel;
        private readonly ILogger<AddUpdateJobWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddUpdateJobWorker(ChannelQueue<JobUpdated> readModelChannel, ILogger<AddUpdateJobWorker> logger, IServiceProvider serviceProvider)
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

                var writeRepository = scope.ServiceProvider.GetRequiredService<IJobRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadJobRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var job = await writeRepository.GetJobByIdAsync(item.JobId);

                        if (job != null)
                        {
                            var mongoJob = new Job
                            {
                                Title = job.Title,
                                JobId = job.Id,
                                HoursOfWork = job.HoursOfWork,
                                SalaryMin = job.SalaryMin,
                                SalaryMax = job.SalaryMax,
                                AnnualLeave = job.AnnualLeave,
                                ExactAmountRecived = job.ExactAmountRecived,
                                Description = job.Description,
                                Email = job.Email,
                                HireCompanies = job.HireCompanies,
                                EmployerId = job.EmployerId
                            };

                            await readRepository.UpdateAsync(mongoJob, x => x.JobId == item.JobId, stoppingToken);
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
