using Application.Contracts;
using Application.Contracts.Identity;
using Application.Models.Common;
using Application.Models.Jwt;
using MediatR;

namespace Application.Features.Account.Queries.RefreshToken
{
    internal class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQuery, OperationResult<AccessToken>>
    {
        private readonly IAppUserManager _userManager;
        private readonly IJwtService _jwtService;
        //private readonly ChannelQueue<CountryAdded> _channel;
        public RefreshTokenQueryHandler(IAppUserManager userManager, IJwtService jwtService/*, ChannelQueue<CountryAdded> channel*/)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            //_channel = channel;
        }
        public async Task<OperationResult<AccessToken>> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {

            var accessToken = await _jwtService.RefreshToken(request.tokenId);
            if (accessToken == null)
                return OperationResult<AccessToken>.FailureResult("Invalid RefreshToken");
            return OperationResult<AccessToken>.SuccessResult(accessToken);
        }
    }
}