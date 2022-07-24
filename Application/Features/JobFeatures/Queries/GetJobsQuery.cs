using Application.Models;
using Application.Models.Common;
using Application.Models.Job;
using MediatR;

namespace Application.Features.JobFeatures.Queries
{
    public record GetJobsQuery() : IRequest<OperationResult<List<GetJobsDto>>>;
}
