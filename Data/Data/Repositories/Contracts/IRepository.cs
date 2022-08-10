using Data.Data.Models;
using System.Linq.Expressions;

namespace Data.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(Guid id);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetLastAsync(Expression<Func<T, bool>> predicate);
        Task<Guid> AddAsync(T book);
        Task UpdateAsync(T book);
        Task RemoveAsync(Guid id);
    }
}
