using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Contract.Commands
{
    public record UpdateSuccessedContractCommand(DateTime date, bool isAmountFixed, decimal amount,
                                                 long jobId, long jobSeekerId, int contractCreatorId) : IRequest<OperationResult<SuccessedContract>>;
}