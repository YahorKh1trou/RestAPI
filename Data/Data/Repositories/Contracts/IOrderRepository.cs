using Data.Data.Models;

namespace Data.Data.Repositories.Contracts
{
    public interface IOrderRepository
    {
        Task<int> AddAsync(Order orders);
        Task<Order> GetAsync(int id);
    }
}
