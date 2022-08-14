using Application.Features.Area.Commands.CreateCountry;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Dto.Area;
using WebFramework.BaseController;
using Application.Features.Area;
using Microsoft.AspNetCore.Authorization;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/Area")]
    [Authorize]
    public class AreaController : BaseController
    {
        private readonly ISender _sender;

        public AreaController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("CreateCountry")]
        public async Task<IActionResult> CreateArea(CreateCountryForm model)
        {
            var commandResult = await _sender.Send(new CreateCountryCommand(model.Title, model.PostalCode, model.AreaCode));

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

        [HttpGet("GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            return base.OperationResult(await _sender.Send(new GetCountriesQuery()));
        }
    }
}
