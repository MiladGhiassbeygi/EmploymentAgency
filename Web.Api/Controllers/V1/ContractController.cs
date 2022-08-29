using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebFramework.BaseController;
using Web.Api.Form.Contract;
using Application.Features.Contract.Commands;
using Microsoft.AspNetCore.Authorization;
using Application.Features.Contract.Queries;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/Contract")]
    [Authorize]
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
            var commandResult = await _sender.Send(new CreateSuccessedContractCommand(model.JobId,model.JobSeekerId,UserId,model.IsAmountFixed,model.Amount));

            if (commandResult.IsSuccess)
            {
                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }

        [HttpPut("UpdateSuccessedContract")]
        public async Task<IActionResult> UpdateSuccessedContract(UpdateSuccessedContractForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new UpdateSuccessedContractCommand(input.Date,input.IsAmountFixed,input.Amount,input.JobId,input.JobSeekerId,input.ContractCreatorId)));
        }


        [HttpGet("GetSuccessedContracts")]
        public async Task<IActionResult> GetSuccessedContracts()
        {
            return base.OperationResult(await _sender.Send(new GetSuccessedContractsQuery()));
            
        }

        [HttpGet("GetSuccessedContractById")]
        public async Task<IActionResult> GetSuccessedContractById(long Id)
        {
            return base.OperationResult(await _sender.Send(new GetSuccessedContractQuery(Id)));
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> Filter([FromQuery] string term)
        {
            return base.OperationResult(await _sender.Send(new FilterSuccessedContractQuery(term, UserId)));
        }
    }
}

