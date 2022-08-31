using Application.Models;
using Application.Models.Common;
using Application.Models.JobModel;
using MediatR;


namespace Application.Features.JobFeatures.JobCommissionCqrs.Queries
{
    public record GetJobCommissionQueries(int userId) : IRequest<OperationResult<List<GetJobCommissionsDto>>>;
}
