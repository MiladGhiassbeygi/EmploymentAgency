using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures.Queries
{
    public record GetJobsQuery() : IRequest<OperationResult<List<Job>>>;
}
