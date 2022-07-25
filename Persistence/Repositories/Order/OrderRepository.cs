using Application.Contracts.Persistence;
using Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class OrderRepository : BaseAsyncRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            var newOrder = order;
            await base.AddAsync(newOrder);
            return newOrder;
        }

        public async Task<Order> DeleteOrderByNameAsync(string Name)
        {
            var fetchedOrder = await base.Table.Where(t => t.OrderName.Equals(Name)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedOrder);
            return fetchedOrder;
        }

        public async Task<List<Order>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new Order
            { 
             OrderName = x.OrderName
            }).ToListAsync();
        }

        public async Task<Order> GetOrderByNameAsync(string name)
        {
            var order = await base.TableNoTracking.FirstOrDefaultAsync(x => x.OrderName.Equals(name));
            return order;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            var fetchedOrder = await base.Table.Where(t => t.OrderName.Equals(order.OrderName)).FirstOrDefaultAsync();

            if (fetchedOrder == null) return null;
            await base.UpdateAsync(fetchedOrder);
            return fetchedOrder;
        }
    }
}
