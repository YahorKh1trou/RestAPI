using Data.Data.Models;
using System.Linq.Expressions;

namespace Data.Repositories.Contracts
{
    public interface IPeopleRepository
    {
        Task<Person> GetIdentityAsync(string username, string password);
        Task<List<Person>> GetAllAsync(Expression<Func<Person, bool>> predicate);
        Task<Person> GetAsync(Expression<Func<Person, bool>> predicate);
        Task<Guid> AddAsync(Person person);
    }
}
