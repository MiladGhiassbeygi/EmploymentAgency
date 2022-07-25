using Domain.Entities;
using Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> GetOrderByNameAsync(string name);
        Task<Order> UpdateOrderAsync(Order order);
        Task<Order> DeleteOrderByNameAsync(string Name);
        Task<List<Order>> GetAll();
    }
}
