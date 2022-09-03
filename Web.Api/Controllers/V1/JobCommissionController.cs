using Application.Features.JobFeatures;
using Application.Features.JobFeatures.JobCommissionCqrs.Commands;
using Application.Features.JobFeatures.JobCommissionCqrs.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Form.JobCommissionForm;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/JobCommission")]
    [ApiController]
    [Authorize]
    public class JobCommissionController : BaseController
    {
        private readonly ISender _sender;

        public JobCommissionController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("CreateJobCommission")]
        public async Task<IActionResult> CreateJobCommission(CreateJobCommissionForm model)
        {
            var commandResult = await _sender.Send(new CreateJobCommissionCommands(model.IsFixed,model.Value, model.JobId));
            return base.OperationResult(commandResult);
        }

        [HttpPut("UpdateJobCommission")]
        public async Task<IActionResult> UpdateJobCommission(UpdateJobCommissionForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new UpdateJobCommissionCommand(input.JobCommissionId, input.IsFixed, input.Value)));
        }

        [HttpDelete("DeleteJobCommission")]
        public async Task<IActionResult> DeleteJobCommission(DeleteJobCommissionForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new DeleteJobCommissionCommand(input.JobCommissionId)));
        }

        [HttpGet("GetJobCommissions")]
        public async Task<IActionResult> GetJobCommissions(long jobCommissionId)
        {
            return base.OperationResult(await _sender.Send(new GetJobCommissionQueries(jobCommissionId)));
        }
    }
}
