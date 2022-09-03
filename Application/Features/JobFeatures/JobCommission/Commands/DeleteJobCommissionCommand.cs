using Application.Models.Common;
using Domain.WriteModel;
using MediatR;


namespace Application.Features.JobFeatures
{
    public record DeleteJobCommissionCommand(long id) : IRequest<OperationResult<JobCommission>>;
}
