using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Contract.Commands
{
    public record UpdateSuccessedContractCommand(long successedContractId,DateTime date, bool isAmountFixed, decimal amount,
                                                 long jobId, long jobSeekerId) : IRequest<OperationResult<SuccessedContract>>;
}