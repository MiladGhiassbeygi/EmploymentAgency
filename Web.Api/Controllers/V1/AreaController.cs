using Application.Features.Area.Commands.AddArea;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/Area")]
    public class AreaController : BaseController
    {
       private readonly ISender _sender;

        public AreaController(ISender sender)
        {
            _sender = sender;
        }

        //[HttpPost("CreateArea")]
        //public async Task<IActionResult> CreateArea(CreateAreaViewModel model)
        //{
        //    var commandResult = await _sender.Send(new AddAreaCommand("Tehran", 021));

        //    return base.OperationResult(commandResult);
        //}
    }
}
