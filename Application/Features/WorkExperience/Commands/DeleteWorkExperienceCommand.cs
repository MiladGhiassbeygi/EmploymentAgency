using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.WorkExperiences.Commands
{
    public record DeleteWorkExperienceCommand(int id) : IRequest<OperationResult<WorkExperience>>;
}  