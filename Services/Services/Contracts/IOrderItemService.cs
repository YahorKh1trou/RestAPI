using Data.Data.Models;

namespace Services.Services.Contracts
{
    public interface IOrderItemService
    {
        Task<OrderItem[]> AddOrderItemsAsync(OrderItem[] orders);
        Task<OrderItem> GetOrderByIdAsync(int id);
    }
}
