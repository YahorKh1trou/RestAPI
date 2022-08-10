using Data.Data.Models;

namespace Services.Services.Contracts
{
    public interface IPeopleService
    {
        Task<IEnumerable<Person>> GetAsync();
        Task<Person> GetOneAsync();
        Task<Person> GetByIdAsync(string username, string password);

        Task<Person> AddPersonAsync(Person person);
    }
}
