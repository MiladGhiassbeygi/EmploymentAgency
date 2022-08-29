using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Contract.Queries
{
    public record FilterSuccessedContractQuery(string term, long userId) : IRequest<OperationResult<List<SuccessedContract>>>;
}
