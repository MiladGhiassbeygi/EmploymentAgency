using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebFramework.BaseController;
using Web.Api.Form.Employer;
using Application.Features.EmployerActivityField;
using Application.Features.EmployerActivityFieldsFeature.Commands.CreateEmployerAcivityField;
using Web.Api.Dto.Employer;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/EmployerAcivityField")]
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

            if (commandResult.IsSuccess)
            {
                CreateEmployerAcivityFieldDto employerAcivityFieldDto = new CreateEmployerAcivityFieldDto()
                {
                    Title = model.Title
                };

                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }

        [HttpGet("GetEmployerAcivityFields")]
        public async Task<IActionResult> GetEmployerAcivityFields()
        {
            return base.OperationResult(await _sender.Send(new GetEmployerAcivityFieldsQuery()));
        }
    }
}
