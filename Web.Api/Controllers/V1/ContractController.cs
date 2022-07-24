using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebFramework.BaseController;
using Web.Api.Form.Contract;
using Application.Features.Contract.Commands;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/Contract")]
    public class ContractController : BaseController
    {
        private readonly ISender _sender;

        public ContractController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("CreateSuccessedContract")]
        public async Task<IActionResult> CreateArea(CreateContractForm model)
        {
            var commandResult = await _sender.Send(new CreateSuccessedContractCommand(model.Id,model.EmployerId,model.JobSeekerId,model.EmploymentAgencyId,model.IsAmountFixed,model.Amount));

            if (commandResult.IsSuccess)
            {
                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }
      
    }
}

