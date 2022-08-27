using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures.Queries.FilterJobSeeker
{
    public record FilterJobSeekerQuery(string term,long userId) : IRequest<OperationResult<List<JobSeeker>>>;


}
