using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebFramework.BaseController;
using Web.Api.Form.Employer;
using Application.Features.Employer.Commands.CreateEmployerAcivityField;
using Application.Features.Employer;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/Employer")]
    public class EmployerController : BaseController
    {
        private readonly ISender _sender;

        public EmployerController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost("CreateEmployerAcivityField")]
        public async Task<IActionResult> CreateEmployerAcivityField(CreateEmployerAcivityFieldForm model)
        {
            var commandResult = await _sender.Send(new CreateEmployerAcivityFieldCommand(model.Title));

            if (commandResult.IsSuccess)
            {
                //CreateCountryDto dto = new CreateCountryDto()
                //{
                //    Id = commandResult.Result.Id,
                //    Title = model.Title,
                //    PostalCode = model.PostalCode,
                //    AreaCode = model.AreaCode,
                //};

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
