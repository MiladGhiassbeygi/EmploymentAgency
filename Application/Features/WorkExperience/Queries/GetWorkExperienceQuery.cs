using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.GetWorkExperience
{
    public record GetWorkExperienceQuery() : IRequest<OperationResult<List<WorkExperience>>>;
}
