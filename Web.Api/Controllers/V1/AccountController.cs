using Application.Features.Account.Commands;
using Application.Features.Admin.Queries.GetToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail()
        {
            return new JsonResult("Endpoint Is Not Implemented ! ");
        }
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> Register()
        {
            return new JsonResult("Endpoint Is Not Implemented ! ");
        }

    }
}