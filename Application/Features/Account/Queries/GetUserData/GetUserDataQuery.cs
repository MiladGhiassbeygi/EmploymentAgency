using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Account.Queries.GetUserData
{
    public record GetUserDataQuery(int userId) : IRequest<OperationResult<User>>;
}
