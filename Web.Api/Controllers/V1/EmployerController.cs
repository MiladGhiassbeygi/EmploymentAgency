using Application.Features.EmployerFeatures.Commands.CreateEmployer;
using Application.Features.EmployerFeatures.Commands.DeleteEmployer;
using Application.Features.EmployerFeatures.Commands.UpdateEmployer;
using Application.Features.EmployerFeatures.Queries;
using Application.Features.EmployerFeatures.Queries.FilterEmpolyer;
using Application.Features.EmployerFeatures.Queries.GetEmployer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Form.Employer;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Employer")]
    [ApiController]
    [Authorize]
    public class EmployerController : BaseController
    {
        private readonly ISender _sender;
        public EmployerController(ISender sender)
        {
            _sender = sender;
        }

        
        [HttpPost("CreateEmployer")]
        public async Task<IActionResult> CreateEmployer(CreateEmployerForm model)
        {
            var commandResult = await _sender.Send(new CreateEmployerCommand
                (
                model.FirstName,model.LastName,model.Address,model.Email,model.WebsiteLink,
                model.PhoneNumber,model.NecessaryExplanation,
                model.IsFixed,model.ExactAmountRecived,model.FieldOfActivityId,UserId));

            return base.OperationResult(commandResult);
        }

        [HttpPut("UpdateEmployer")]
        public async Task<IActionResult> UpdateEmployer(UpdateEmployerForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new UpdateEmployerCommand(input.Id,input.FirstName,input.LastName,input.Address,input.PhoneNumber,input.Email,input.WebsiteLink,
                input.NecessaryExplanation,input.IsFixed,input.ExactAmountRecived,input.FieldOfActivityId)));
        }

        [HttpPost("DeleteEmployer")]
        public async Task<IActionResult> DeleteEmployer(DeleteEmployerForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new DeleteEmployerCommand(input.Id)));
        }

        [HttpGet("GetEmployers")]
        public async Task<IActionResult> GetEmployers()
        {
            return base.OperationResult(await _sender.Send(new GetEmployersQuery()));
        }

        [HttpGet("GetEmployer")]
        public async Task<IActionResult> GetEmployerById(long Id)
        {
            return base.OperationResult(await _sender.Send(new GetEmployerQuery(Id)));
        }
        [HttpGet("Filter")]
        public async Task<IActionResult> Filter([FromQuery] string term)
        {
            return base.OperationResult(await _sender.Send(new FilterEmpolyerQuery(term)));
        }
    }
}