using Application.Features.EmployerFeatures.Commands;
using Application.Features.EmployerFeatures.EmployerCommissionCqrs.Commands;
using Application.Features.EmployerFeatures.EmployerCommissionCqrs.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Dto.EmployerCommissionDto;
using Web.Api.Form.EmployerCommissionForm;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/EmployerCommission")]
    [ApiController]
    [Authorize]
    public class EmployerCommissionController : BaseController
    {
        private readonly ISender _sender;

        public EmployerCommissionController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("CreateEmployerCommission")]
        public async Task<IActionResult> CreateEmployerCommission(CreateEmployerCommissionForm model)
        {
            var commandResult = await _sender.Send(new CreateEmployerCommissionCommand(
               model.IsFixed, model.Value, model.EmployerId
                ));

            if (commandResult.IsSuccess)
            {
                CreateEmployerCommissionDto employerCommissionDto = new CreateEmployerCommissionDto()
                {
                    IsFixed = model.IsFixed,
                    Value = model.Value,
                    EmployerId = model.EmployerId
                };

                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }

        [HttpPut("UpdateEmployerCommission")]
        public async Task<IActionResult> UpdateEmployerCommission(UpdateEmployerCommissionForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new UpdateEmployerCommissionCommand(input.EmployerCommissionId,input.IsFixed,input.Value)));
        }

        [HttpDelete("DeleteEmployerCommission")]
        public async Task<IActionResult> DeleteEmployerCommission(DeleteEmployerCommissionForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new DeleteEmployerCommissionCommand(input.EmployerCommissionId)));
        }

        [HttpGet("GetEmployerCommissions")]
        public async Task<IActionResult> GetEmployerCommissions()
        {
            return base.OperationResult(await _sender.Send(new GetEmployerCommissionQuery()));
        }
    }
}
