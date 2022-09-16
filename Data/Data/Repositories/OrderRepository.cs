using Data.Data.EF;
using Data.Data.Models;
using Data.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.Repositories
{
    internal sealed class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _db;

        public OrderRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<int> AddAsync(Order order)
        {
            //            await _db.AddAsync(orders);
            await _db.AddAsync(order);
            await _db.SaveChangesAsync();
//            return order;
            return order.Id;
        }
        public async Task<Order> GetAsync(int id)
            => await _db.Orders.SingleOrDefaultAsync(x => x.Id == id);
    }
}
