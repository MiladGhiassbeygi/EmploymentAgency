using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Features.JobFeatures.Commands.CreateJob;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
using Utils;

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

            bool EssentialSkillsHasValue;
            bool UnnecessarySkillsHasValue;

            EssentialSkillsHasValue = string.IsNullOrEmpty(request.EssentialSkills);
            UnnecessarySkillsHasValue = string.IsNullOrEmpty(request.UnnecessarySkills);

            if (!EssentialSkillsHasValue)
                if (!IsSkillIdsAreShort(request.EssentialSkills.Split(',')))
                    return OperationResult<Job>.FailureResult("Essential SkillIds Are Invalid");

            if (!UnnecessarySkillsHasValue)
                if (!IsSkillIdsAreShort(request.UnnecessarySkills.Split(',')))
                    return OperationResult<Job>.FailureResult("Unnessecary SkillIds Are Invalid");




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
            if (!EssentialSkillsHasValue)
                foreach (var skillId in request.EssentialSkills.Split(','))
                {
                    await _unitOfWork.JobEssentialSkillsRepository.CreateJobEssentialSkillsAsync(new JobEssentialSkills { JobId = job.Id, SkillId = short.Parse(skillId) });
                }

            if (!UnnecessarySkillsHasValue)
                foreach (var skillId in request.UnnecessarySkills.Split(','))
                {
                    await _unitOfWork.JobUnnessecarySkillsRepository.CreateJobUnnessecarySkillsAsync(new JobUnnecessarySkills { JobId = job.Id, SkillId = short.Parse(skillId) });
                }

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new JobAdded { JobId = job.Id, DefinerId = request.DefinerId }, cancellationToken);

            return OperationResult<Job>.SuccessResult(result);
        }

        private bool IsSkillIdsAreShort(string[] skillIds)
        {
            if (skillIds.Count() == 0)
                return true;
            foreach (var skiilId in skillIds)
            {
                short shortSkillId;
                if (!short.TryParse(skiilId, out shortSkillId))
                    return false;
            }

            return true;
        }
    }
}
