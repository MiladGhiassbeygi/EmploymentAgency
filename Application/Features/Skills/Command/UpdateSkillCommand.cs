using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Skills.Command
{
    public record UpdateSkillCommand(short id, string title, byte percentage) : IRequest<OperationResult<Skill>>;
}
