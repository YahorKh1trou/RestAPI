using Data.Data.Models;
using Data.Repositories.Contracts;
using Services.Services.Contracts;

namespace Services.Services
{
    internal sealed class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleService(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        public async Task<Person> GetByIdAsync(string username, string password)
        {
            return await _peopleRepository.GetIdentityAsync(username, password);
        }

        public async Task<IEnumerable<Person>> GetAsync()
        {
            return await _peopleRepository.GetAllAsync(x => true);
        }
        public async Task<Person> AddPersonAsync(Person person)
        {
            person.Id = await _peopleRepository.AddAsync(person);
            return person;
        }

        public async Task<Person> GetOneAsync()
        {
            return await _peopleRepository.GetAsync(x => true);
        }
    }
}
