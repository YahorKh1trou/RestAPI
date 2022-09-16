using Data.Data.Models;
using Data.Data.Repositories.Contracts;
using Services.Services.Contracts;

namespace Services.Services
{
    internal sealed class OrderService : IOrderService
    {
        private readonly IOrderRepository _ordersRepository;

        public OrderService(IOrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public async Task<Order> AddOrderAsync(Order orders)
        {
            orders.Id = await _ordersRepository.AddAsync(orders);
            return orders;
        }
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _ordersRepository.GetAsync(id);
        }
    }
}
