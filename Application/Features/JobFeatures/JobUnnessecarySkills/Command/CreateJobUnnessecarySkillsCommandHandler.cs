using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.JobFeatures.Command
{
    internal class CreateJobUnnessecarySkillsCommandHandler : IRequestHandler<CreateJobUnnessecarySkillsCommand, OperationResult<JobUnnessecarySkills>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<JobUnnessecarySkillsAdded> _channel;
        public CreateJobUnnessecarySkillsCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<JobUnnessecarySkillsAdded> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<JobUnnessecarySkills>> Handle(CreateJobUnnessecarySkillsCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.JobUnnessecarySkillsRepository.GetJobUnnessecarySkillsByIdAsync(request.jobId) is not null)
                return OperationResult<JobUnnessecarySkills>.FailureResult("This Job Unnecessary Skill Already Exists");

            var jobUnnecessarySkill = new JobUnnessecarySkills
            {
                JobId = request.jobId,
                SkillId = request.skillId
            };

            var result = await _unitOfWork.JobUnnessecarySkillsRepository.CreateJobUnnessecarySkillsAsync(jobUnnecessarySkill);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new JobUnnessecarySkillsAdded { JobUnnessecarySkillId = jobUnnecessarySkill.Id }, cancellationToken);

            return OperationResult<JobUnnessecarySkills>.SuccessResult(jobUnnecessarySkill);
        }
    }
}
