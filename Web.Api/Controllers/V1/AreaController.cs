using Application.Features.Area.Commands.CreateCountry;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Dto.Area;
using WebFramework.BaseController;
using Application.Features.Area;
using Microsoft.AspNetCore.Authorization;
using Web.Api.Form.Area;
using Application.Features.Area.Commands;

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
                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }

        [HttpPut("UpdateCountry")]
        public async Task<IActionResult> UpdateCountry(UpdateCountryForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new UpdateCountryCommand(input.CountryId, input.Title,input.PostalCode,input.AreaCode)));
        }

        [HttpGet("GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            return base.OperationResult(await _sender.Send(new GetCountriesQuery()));
        }
    }
}
