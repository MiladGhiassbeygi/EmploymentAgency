using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebFramework.BaseController;
using Web.Api.Form.Employer;
using Application.Features.GetEmployerActivityField;
using Application.Features.EmployerActivityFieldsFeature.Commands.CreateEmployerAcivityField;
using Web.Api.Dto.Employer;
using Web.Api.Form.EmployerAcivityField;
using Application.Features.EmployerActivityFieldsFeature.Queries.FilterEmployerAcivityField;
using Domain.ReadModel;
using Domain.WriteModel.User;
using Microsoft.AspNetCore.Authorization;
using Application.Features.EmployerFeatures.Commands;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/EmployerAcivityField")]
    [Authorize]
    public class EmployerAcivityFieldController : BaseController
    {
        private readonly ISender _sender;

        public EmployerAcivityFieldController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost("CreateEmployerAcivityField")]
        public async Task<IActionResult> CreateEmployerAcivityField(CreateEmployerAcivityFieldForm model)
        {
            var commandResult = await _sender.Send(new CreateEmployerAcivityFieldCommand(model.Title));

            //if (commandResult.IsSuccess)
            //{
            CreateEmployerAcivityFieldDto employerAcivityFieldDto = new CreateEmployerAcivityFieldDto()
            {

                Title = model.Title
            };

            //return base.OperationResult(commandResult);
            //}
            return base.OperationResult(commandResult);
        }

        [HttpPut("UpdateEmployerAcivityField")]
        public async Task<IActionResult> UpdateEmployerAcivityFields(UpdateEmployerAcivityFieldForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new UpdateEmployerActivityFieldCommand(input.EmployerAcivityFieldId,input.Title)));
        }

        [HttpDelete("DeleteEmployerAcivityField")]
        public async Task<IActionResult> DeleteEmployerAcivityField(DeleteEmployerAcivityFieldsForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new DeleteEmployerAcivityFieldCommand(input.EmployerAcivityFieldId)));
        }

        [HttpGet("GetEmployerAcivityFields")]
        public async Task<IActionResult> GetEmployerAcivityFields()
        {
            return base.OperationResult(await _sender.Send(new GetEmployerAcivityFieldsQuery()));
        }

        [HttpGet("FilterEmployerActivityFields")]
        public async Task<IActionResult> FilterEmployerActivityFields([FromQuery]FilterEmployerActivityFieldForm form)
        {
            
            
            return base.OperationResult(await _sender.Send(new FilterEmployerAcivityFieldCommand(form.Term)));
            
        }


    }
}
