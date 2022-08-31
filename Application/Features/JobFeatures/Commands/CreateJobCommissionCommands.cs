using Application.Models.Common;
using MediatR;
using Domain.WriteModel;

namespace Application.Features.JobFeatures.JobCommissionCqrs.Commands
{
    public record CreateJobCommissionCommands(bool IsFixed,int Value,long JobId,int DefinerId) : IRequest<OperationResult<JobCommission>>;
}
