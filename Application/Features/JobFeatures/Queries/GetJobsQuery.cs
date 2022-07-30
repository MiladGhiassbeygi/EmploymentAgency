using Application.Models.Common;
using Application.Models.JobModel;
using MediatR;

namespace Application.Features.JobFeatures.Queries
{
    public record GetJobsQuery() : IRequest<OperationResult<List<GetJobsDto>>>;
}
