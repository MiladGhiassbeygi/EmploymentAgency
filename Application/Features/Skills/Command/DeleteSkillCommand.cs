using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Skills.Command
{
    public record DeleteSkillCommand(short id) : IRequest<OperationResult<Skill>>;
}
