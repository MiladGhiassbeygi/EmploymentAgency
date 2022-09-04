using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures.Queries
{
    public record GetJobQuery(long Id) : IRequest<OperationResult<Job>>;
}
