using Data.Data.Models;
using System.Linq.Expressions;

namespace Data.Repositories.Contracts
{
    public interface IOrderItemRepository
    {
        Task<OrderItem[]> AddAsync(OrderItem[] orderitems);
        Task<OrderItem> GetAsync(int id);
        //        Task<Order> CreateAsync();
        //        Task<Order> GetByIdAsync(int id);
        //        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        //        Task Update(Order order);
    }
}
