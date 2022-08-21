using Application.Contracts.Persistence;
using Application.Models.Common;
using Application.Models.JobModel;
using MediatR;

namespace Application.Features.JobFeatures.JobEssentialSkills.Query
{
    internal class GetJobEssentialSkillsQueryHandler : IRequestHandler<GetJobEssentialSkillsQuery, OperationResult<List<GetJobEssentialSkillsDto>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetJobEssentialSkillsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<GetJobEssentialSkillsDto>>> Handle(GetJobEssentialSkillsQuery request, CancellationToken cancellationToken)
        {

            var jobEssentialSkills = await _unitOfWork.JobEssentialSkillsRepository.GetAll();

            if (jobEssentialSkills is not null)
            {
                var jobEssentialSkillsDto = new List<GetJobEssentialSkillsDto>();
                jobEssentialSkillsDto.AddRange(jobEssentialSkills.ConvertAll(x => new GetJobEssentialSkillsDto()
                {
                  JobId=x.JobId
                  ,SkillId=x.SkillId
                }));

                return OperationResult<List<GetJobEssentialSkillsDto>>.SuccessResult(jobEssentialSkillsDto);

            }

            return OperationResult<List<GetJobEssentialSkillsDto>>.FailureResult("There is no Job Essential Skills !!!");
        }
    }
}
