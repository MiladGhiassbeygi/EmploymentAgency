using Application.Contracts.Persistence;
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
    internal class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OperationResult<List<GetOrderDto>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetOrderQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<GetOrderDto>>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {

            var orders = await _unitOfWork.OrderRepository.GetAll();

            if (orders is not null)
            {
                var ordersDto = new List<GetOrderDto>();
                ordersDto.AddRange(orders.ConvertAll(x => new GetOrderDto()
                {
                   OrderName=x.OrderName
                }));

                return OperationResult<List<GetOrderDto>>.SuccessResult(ordersDto);

            }

            return OperationResult<List<GetOrderDto>>.FailureResult("There is no order !!!");
        }
    }
}
