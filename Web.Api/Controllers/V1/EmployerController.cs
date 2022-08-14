using Application.Features.EmployerFeatures.Commands.CreateEmployer;
using Application.Features.EmployerFeatures.Queries.FilterEmpolyer;
using Application.Features.EmployerFeatures.Queries.GetEmployer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Dto.Employer;
using Web.Api.Form.Employer;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Employer")]
    [ApiController]
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
                model.FirstName,
                model.LastName,
                model.Address,
                model.Email,
                model.WebsiteLink,
                model.PhoneNumber,
                model.NecessaryExplanation,
                model.FieldOfActivityId
                ));

            if (commandResult.IsSuccess)
            {
                CreateEmployerDto employerDto = new CreateEmployerDto()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Email = model.Email,
                    WebsiteLink = model.WebsiteLink,
                    PhoneNumber = model.PhoneNumber,
                    NecessaryExplanation = model.NecessaryExplanation,
                    FieldOfActivityId = model.FieldOfActivityId
                };

                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }


        [HttpGet("GetEmployer")]
        public async Task<IActionResult> GetEmployer()
        {
            return base.OperationResult(await _sender.Send(new GetEmployerQuery()));
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> Filter([FromQuery] string term)
        {
            return base.OperationResult(await _sender.Send(new FilterEmpolyerQuery(term)));
        }
    }
}