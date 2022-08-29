using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Contract.Queries
{
    public record GetSuccessedContractsQuery() : IRequest<OperationResult<List<SuccessedContract>>>;
}
