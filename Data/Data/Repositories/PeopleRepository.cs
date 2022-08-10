using Data.Data.EF;
using Data.Data.Models;
using Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    internal sealed class PeopleRepository : IPeopleRepository
    {
        private readonly ApplicationContext _db;

        public PeopleRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<List<Person>> GetAllAsync(Expression<Func<Person, bool>> predicate)
            => await _db.People.Where(predicate).ToListAsync();

        public async Task<Person> GetIdentityAsync(string username, string password)
            => await _db.People.SingleOrDefaultAsync(x => x.Login == username && x.Password == password);

        public async Task<Person> GetAsync(Expression<Func<Person, bool>> predicate)
            => (await GetAllAsync(predicate)).LastOrDefault();
        public async Task<Guid> AddAsync(Person person)
        {
            await _db.AddAsync(person);
            await _db.SaveChangesAsync();
            return person.Id;
        }
    }
}
