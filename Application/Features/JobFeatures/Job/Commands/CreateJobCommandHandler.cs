using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Features.JobFeatures.Commands.CreateJob;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

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
                Email = request.email,
                HireCompanies = request.hireCompanies,
                EmployerId = request.EmployerId

            };

            var result = await _unitOfWork.JobRepository.CreateJobAsync(job);

            await _unitOfWork.CommitAsync();

            if (request.EssentialSkills.Count() > 0)
                foreach (var skillId in request.EssentialSkills)
                {
                    if (skillId != 0)
                        await _unitOfWork.JobEssentialSkillsRepository.CreateJobEssentialSkillsAsync(new JobEssentialSkills { JobId = job.Id, SkillId = skillId });
                }
            if (request.UnnecessarySkills.Count() > 0)
                foreach (var skillId in request.UnnecessarySkills)
                {
                    if (skillId != 0)
                        await _unitOfWork.JobUnnessecarySkillsRepository.CreateJobUnnessecarySkillsAsync(new JobUnnessecarySkills { JobId = job.Id, SkillId = skillId });
                }

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new JobAdded { JobId = job.Id, DefinerId = request.DefinerId }, cancellationToken);

            return OperationResult<Job>.SuccessResult(result);
        }
    }
}