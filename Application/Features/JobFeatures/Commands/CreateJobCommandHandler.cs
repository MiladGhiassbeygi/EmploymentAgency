using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Features.JobFeatures.Commands.CreateJob;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
using MongoDB.Driver.Core.Bindings;

namespace Application.Features.JobFeature.Commands.CreateJob
{
    internal class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, OperationResult<Job>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<JobAdded> _channel;

        public CreateJobCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<JobAdded> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<Job>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.JobRepository.GetJobByTitleAsync(request.Title) is not null)
                return OperationResult<Job>.FailureResult("This Job Already Exists");

            var job = new Job
            {

                Title = request.Title,
                HoursOfWork = request.HoursOfWork,
                SalaryMin = request.SalaryMin,
                SalaryMax = request.SalaryMax,
                AnnualLeave = request.AnnualLeave,
                ExactAmountRecived = request.ExactAmountRecived,
                Description = request.Description,
                EssentialSkills = request.EssentialSkills,
                UnnecessarySkills = request.UnnecessarySkills,
                EmployerId = request.EmployerId

            };

            var result = await _unitOfWork.JobRepository.CreateJobAsync(job);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new JobAdded { JobId = job.Id }, cancellationToken);

            return OperationResult<Job>.SuccessResult(job);
        }
    }
}
