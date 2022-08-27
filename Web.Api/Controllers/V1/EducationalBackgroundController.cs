using Application.Features.EducationalBackgrounds.Commands;
using Application.Features.EducationalBackgrounds.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Form;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/EducationalBackground")]
    public class EducationalBackgroundController : BaseController
    {
        private readonly ISender _sender;

        public EducationalBackgroundController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("CreateEducationalBackground")]
        public async Task<IActionResult> CreateEducationalBackground([FromBody]CreateEducationalBackgroundForm input)
        {
            var commandResult = await _sender.Send(new CreateEducationalBackgroundCommand(input.School,input.Degree,input.FieldOfStudy,input.StartDate,input.EndDate,input.JobSeekerId));
            return base.OperationResult(commandResult);
        }

        [HttpPut("UpdateEducationalBackground")]
        public async Task<IActionResult> UpdateEducationalBackground([FromBody]UpdateEducationalBackgroundForm input)
        {
            var commandResult = await _sender.Send(new UpdateEducationalBackgroundCommand(input.Id,input.School, input.Degree, input.FieldOfStudy, input.StartDate, input.EndDate, input.JobSeekerId));
            return base.OperationResult(commandResult);
        }

        [HttpDelete("DeleteEducationalBackground")]
        public async Task<IActionResult> DeleteEducationalBackground(int Id)
        {
            var commandResult = await _sender.Send(new DeleteEducationalBackgroundCommand(Id));
            return base.OperationResult(commandResult);
        }

        [HttpGet("GetEducationalBackgrounds")]
        public async Task<IActionResult> GetEducationalBackgrounds()
        {
            var queryResult = await _sender.Send(new GetEducationalBackgroundsQuery());
            return base.OperationResult(queryResult);
        }

        [HttpGet("GetEducationalBackground")]
        public async Task<IActionResult> GetEducationalBackground(int Id)
        {
            var queryResult = await _sender.Send(new GetEducationalBackgroundQuery(Id));
            return base.OperationResult(queryResult);
        }
        

    }
}
