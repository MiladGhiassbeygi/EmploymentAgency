using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.JobFeatures
{
    public record UpdateJobCommissionCommand(long id,bool isFixed,int value) : IRequest<OperationResult<JobCommission>>;
}
