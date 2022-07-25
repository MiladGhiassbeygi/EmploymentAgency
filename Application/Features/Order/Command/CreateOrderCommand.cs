using Application.Models.Common;
using Domain.Entities.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command
{
    public record CreateOrderCommand(string OrderName) : IRequest<OperationResult<Order>>;
}
