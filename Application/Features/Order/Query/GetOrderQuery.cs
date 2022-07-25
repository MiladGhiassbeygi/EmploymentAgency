using Application.Models.Common;
using Application.Models.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Query
{
    public record GetOrderQuery() : IRequest<OperationResult<List<GetOrderDto>>>;
}
