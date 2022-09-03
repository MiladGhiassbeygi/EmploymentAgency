using Application.Models.Common;
using Application.Models.JobModel;
using MediatR;


namespace Application.Features.JobFeatures.JobCommissionCqrs.Queries
{
    public record GetJobCommissionQueries(long jobCommissionId) : IRequest<OperationResult<List<GetJobCommissionsDto>>>;
}
