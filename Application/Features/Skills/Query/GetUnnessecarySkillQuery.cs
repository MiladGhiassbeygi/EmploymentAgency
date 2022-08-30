using Application.Models.Common;
using Application.Models.Skill;
using MediatR;

namespace Application.Features.Skills.Query
{
    public record GetUnnessecarySkillQuery(short[] essentialSkills) : IRequest<OperationResult<List<GetSkillDto>>>;
}
