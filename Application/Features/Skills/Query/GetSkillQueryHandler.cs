using Application.Contracts.Persistence;
using Application.Models.Common;
using Application.Models.Skill;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skills.Query
{
    internal class GetSkillQueryHandler : IRequestHandler<GetSkillQuery, OperationResult<List<GetSkillDto>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetSkillQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<GetSkillDto>>> Handle(GetSkillQuery request, CancellationToken cancellationToken)
        {

            var skills = await _unitOfWork.SkillRepository.GetAll();

            if (skills is not null)
            {
                var skillsDto = new List<GetSkillDto>();
                skillsDto.AddRange(skills.ConvertAll(x => new GetSkillDto()
                {
                   Title = x.Title
                }));

                return OperationResult<List<GetSkillDto>>.SuccessResult(skillsDto);

            }

            return OperationResult<List<GetSkillDto>>.FailureResult("There is no skill !!!");
        }
    }
}
