using Application.Command;
using Application.Features.Order.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Form.Order;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Order")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly ISender _sender;

        public OrderController(ISender sender)
        {
            _sender = sender;
        }


        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderForm model)
        {
            var commandResult = await _sender.Send(new CreateOrderCommand(model.OrderName));

            if (commandResult.IsSuccess)
            {
                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            return base.OperationResult(await _sender.Send(new GetOrderQuery()));
        }
    }
}
