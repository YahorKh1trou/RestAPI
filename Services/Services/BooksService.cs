using Data.Data.Models;
using Data.Repositories.Contracts;
using Services.Services.Contracts;

namespace Services.Services
{
    internal sealed class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _booksRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _booksRepository.GetAllAsync(x => true);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            await _booksRepository.AddAsync(book);
            return book;
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            await _booksRepository.UpdateAsync(book);
            return book;
        }

        public async Task DeleteBookAsync(Book book)
        {
            await _booksRepository.RemoveAsync(book.Id);
        }
    }
}
