using Application.Models.Common;
using Application.Models.Jwt;
using MediatR;

namespace Application.Features.Account.Queries.RefreshToken
{
    public record RefreshTokenQuery(string tokenId) : IRequest<OperationResult<AccessToken>>;
}
