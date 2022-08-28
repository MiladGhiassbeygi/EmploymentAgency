using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Command
{
    internal class CreateJobEssentialSkillsCommandHandler : IRequestHandler<CreateJobEssentialSkillsCommand, OperationResult<JobEssentialSkills>>
    {
        readonly IUnitOfWork _unitOfWork;

        public CreateJobEssentialSkillsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<JobEssentialSkills>> Handle(CreateJobEssentialSkillsCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.JobEssentialSkillsRepository.GetJobEssentialSkillsByIdAsync(request.SkillId) is not null)
                return OperationResult<JobEssentialSkills>.FailureResult("This Job Essential Skill Already Exists");

            var jobEssentialSkills = new JobEssentialSkills { SkillId=request.SkillId,JobId=request.JobId };

            var result = await _unitOfWork.JobEssentialSkillsRepository.CreateJobEssentialSkillsAsync(jobEssentialSkills);

            await _unitOfWork.CommitAsync();

            return OperationResult<JobEssentialSkills>.SuccessResult(jobEssentialSkills);
        }
    }
}
