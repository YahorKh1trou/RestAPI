using Data.Data.Models;
using Data.Repositories.Contracts;
using Services.Services.Contracts;

namespace Services.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _ordersRepository;

        public OrderItemService(IOrderItemRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public async Task<OrderItem[]> AddOrderItemsAsync(OrderItem[] orders)
        {
            return await _ordersRepository.AddAsync(orders);
        }

        public async Task<OrderItem> GetOrderByIdAsync(int id)
        {
            return await _ordersRepository.GetAsync(id);
        }
    }
}
