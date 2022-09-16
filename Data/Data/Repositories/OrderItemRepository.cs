using Data.Data.EF;
using Data.Data.Models;
using Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    internal sealed class OrderItemRepository : IOrderItemRepository
    {
//        private readonly List<Order> orders = new List<Order>();
        private readonly ApplicationContext _db;

        public OrderItemRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<OrderItem[]> AddAsync(OrderItem[] orders)
        {
//            await _db.AddAsync(orders);
            await _db.AddRangeAsync(orders);
            await _db.SaveChangesAsync();
            return orders;
        }
        public async Task<OrderItem> GetAsync(int id)
            => await _db.OrderItems.SingleOrDefaultAsync(x => x.Id == id);
        /*
                public async Task<Order> CreateAsync()
                {
                    //            int nextId = orders.Count + 1;
                    int nextId = _db.Orders.Count() + 1;
                    var order = new Order(nextId, new OrderItem[0]);

        //            orders.Add(order);
                    await _db.AddAsync(order);
                    await _db.SaveChangesAsync();

                    return order;
                }

                public async Task<Order> GetByIdAsync(int id) 
                    => await _db.Orders.SingleAsync(order => order.Id == id);
        */
    }
}
