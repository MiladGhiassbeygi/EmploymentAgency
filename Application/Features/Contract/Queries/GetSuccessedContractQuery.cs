using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Contract.Queries
{
    public record GetSuccessedContractQuery(long Id) : IRequest<OperationResult<SuccessedContract>>;
}

