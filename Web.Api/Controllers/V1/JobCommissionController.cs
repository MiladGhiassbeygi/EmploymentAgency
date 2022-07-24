using Application.Features.JobFeatures.JobCommissionCqrs.Commands;
using Application.Features.JobFeatures.JobCommissionCqrs.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Dto.JobCommissionsDto;
using Web.Api.Form.JobCommissionForm;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/JobCommission")]
    [ApiController]
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
            var commandResult = await _sender.Send(new CreateJobCommissionCommands(
               model.IsFixed,model.Value, model.JobId
                ));

            if (commandResult.IsSuccess)
            {
                CreateJobCommissionsDto jobCommissionDto = new CreateJobCommissionsDto()
                {
                   IsFixed = model.IsFixed,
                   Value = model.Value,
                   JobId = model.JobId
                };

                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }

        [HttpGet("GetJobCommissions")]
        public async Task<IActionResult> GetJobCommissions()
        {
            return base.OperationResult(await _sender.Send(new GetJobCommissionQueries()));
        }
    }
}
