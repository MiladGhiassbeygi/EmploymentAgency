using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures
{
    public record GetAvailableJobsForJobSeekerQuery(long jobSeekerId,long definerId) : IRequest<OperationResult<List<Job>>>;
}
