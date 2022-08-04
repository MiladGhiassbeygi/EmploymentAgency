using Application.Models.Common;
using Domain.WriteModel.User;
using MediatR;

namespace Application.Features.Account.Commands
{
    public record CreateAccountCommand(string Name, string Password, string Email) : IRequest<OperationResult<User>>;
}
