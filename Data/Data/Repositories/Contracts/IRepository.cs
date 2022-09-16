using Data.Data.Models;
using System.Linq.Expressions;

namespace Data.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetByNameAsync(string bookname);
        Task<List<T>> GetByAuthorAsync(string lastname);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetLastAsync(Expression<Func<T, bool>> predicate);
        Task<int> AddAsync(T book);
        Task UpdateAsync(T book);
        Task RemoveAsync(int id);
    }
}
