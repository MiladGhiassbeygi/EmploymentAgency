using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures.Query
{
    internal class GetJobUnnessecarySkillsQueryHandler : IRequestHandler<GetJobUnnessecarySkillsQuery, OperationResult<List<JobUnnecessarySkills>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetJobUnnessecarySkillsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<JobUnnecessarySkills>>> Handle(GetJobUnnessecarySkillsQuery request, CancellationToken cancellationToken)
        {

            var jobUnnecessarySkills = await _unitOfWork.ReadJobUnnessecarySkillsRepository.GetAllAsync();

            if (jobUnnecessarySkills is not null)
                return OperationResult<List<JobUnnecessarySkills>>.SuccessResult(jobUnnecessarySkills);

            return OperationResult<List<JobUnnecessarySkills>>.FailureResult("There is no job unnecessary skill !!!");
        }
    }
}
