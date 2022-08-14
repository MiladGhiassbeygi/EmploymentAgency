using Application.Features.Account.Commands;
using Application.Features.Account.Queries.GetUserData;
using Application.Features.Account.Queries.RefreshToken;
using Application.Features.Admin.Queries.GetToken;
using Application.Models.ApiResult;
using Domain.ReadModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utils;
using Web.Api.Form.Account;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/Account")]
    public class AccountController : BaseController
    {
        private readonly ISender _sender;

        public AccountController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterForm input)
        {
            var commandResult = await _sender.Send(new CreateAccountCommand(input.Name, input.Password, input.Email));

            if (commandResult.IsSuccess)
            {
                AdminGetTokenQuery tokenQuery = new AdminGetTokenQuery()
                {
                    UserName = input.Email,
                    Password = input.Password
                };
                var tokenResult = await _sender.Send(tokenQuery);
                return base.OperationResult(tokenResult);
            }
            return base.OperationResult(commandResult);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginForm loginForm)
        {
            var tokenResult = await _sender.Send(new AdminGetTokenQuery { UserName = loginForm.Email, Password = loginForm.Password });
            return base.OperationResult(tokenResult);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenForm refreshToken)
        {
            var refreshResult = await _sender.Send(new RefreshTokenQuery(refreshToken.TokenId));
            return base.OperationResult(refreshResult);
        }

        [Authorize]
        [HttpGet("GetUserData")]
        public async Task<IActionResult> GetUserData()
        {
            var user = await _sender.Send(new GetUserDataQuery(UserId));
            return base.OperationResult(user);
        }
    }
}