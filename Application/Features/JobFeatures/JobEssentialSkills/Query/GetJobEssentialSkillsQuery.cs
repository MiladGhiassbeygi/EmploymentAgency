using Application.Models.Common;
using Application.Models.JobModel;
using MediatR;

namespace Application.Features.JobFeatures.JobEssentialSkills.Query
{
    public record GetJobEssentialSkillsQuery() : IRequest<OperationResult<List<GetJobEssentialSkillsDto>>>;
}
