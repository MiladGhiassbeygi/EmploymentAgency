using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
namespace Application.Features.Contract.Commands
{
    public record DeleteSuccessedContractCommand(long id) : IRequest<OperationResult<SuccessedContract>>;
}
