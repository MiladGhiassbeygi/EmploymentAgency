using Application.Models.Common;
using Domain.WriteModel;
using MediatR;


namespace Application.Features.Contract.Commands
{
    public record CreateSuccessedContractCommand(long jobId,long jobSeekerId,int contractCreatorId, bool isAmountFixed,decimal amount) : IRequest<OperationResult<SuccessedContract>>;
}


