using Application.Command;
using Application.Contracts.Persistence;
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
    internal class CreateOrderNameHandler : IRequestHandler<CreateOrderCommand, OperationResult<Order>>
    {
        readonly IUnitOfWork _unitOfWork;

        public CreateOrderNameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.OrderRepository.GetOrderByNameAsync(request.OrderName) is not null)
                return OperationResult<Order>.FailureResult("This Order Already Exists");

            var order = new Order { OrderName = request.OrderName};

            var result = await _unitOfWork.OrderRepository.CreateOrderAsync(order);

            await _unitOfWork.CommitAsync();

            return OperationResult<Order>.SuccessResult(order);
        }
    }
}
