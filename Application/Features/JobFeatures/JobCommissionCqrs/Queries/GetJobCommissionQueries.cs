using Application.Models;
using Application.Models.Common;
using Application.Models.Job;
using Application.Models.JobModel;
using MediatR;


namespace Application.Features.JobFeatures.JobCommissionCqrs.Queries
{
    public record GetJobCommissionQueries() : IRequest<OperationResult<List<GetJobCommissionsDto>>>;
}
