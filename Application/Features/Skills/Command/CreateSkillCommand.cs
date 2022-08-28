using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Skills.Command
{
    public record CreateSkillCommand(string Title,byte Percentage) : IRequest<OperationResult<Skill>>;
}
