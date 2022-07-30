using Application.Features.Account.Commands;
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
            var commandResult = await _sender.Send(new CreateAccountCommand(input.Name,input.Password,input.Email));
            return base.OperationResult(commandResult);
            
            
            
            //if (commandResult.IsSuccess)
            //{
                
            //}
            //return base.OperationResult("Broken User");
            
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login()
        {
            return new JsonResult("Endpoint Is Not Implemented ! ");
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