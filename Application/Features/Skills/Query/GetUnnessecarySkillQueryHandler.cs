using Application.Contracts.Persistence;
using Application.Models.Common;
using Application.Models.Skill;
using MediatR;

namespace Application.Features.Skills.Query
{
    internal class GetUnnessecarySkillQueryHandler : IRequestHandler<GetUnnessecarySkillQuery, OperationResult<List<GetSkillDto>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetUnnessecarySkillQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<GetSkillDto>>> Handle(GetUnnessecarySkillQuery request, CancellationToken cancellationToken)
        {

            var skills = await _unitOfWork.ReadSkillRepository.GetWithFilterAsync(x => !request.essentialSkills.Contains(x.SkillId));

            if (skills is not null)
            {
                var skillsDto = new List<GetSkillDto>();
                skillsDto.AddRange(skills.ConvertAll(x => new GetSkillDto()
                {
                   Title = x.Title,
                   Id = x.SkillId,
                }));

                return OperationResult<List<GetSkillDto>>.SuccessResult(skillsDto);

            }

            return OperationResult<List<GetSkillDto>>.FailureResult("There is no skill !!!");
        }
    }
}
