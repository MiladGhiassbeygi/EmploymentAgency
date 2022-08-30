using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures.Query
{
    public record GetJobUnnessecarySkillsQuery : IRequest<OperationResult<List<JobUnnecessarySkills>>>;
}
