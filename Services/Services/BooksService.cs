using Data.Data.Models;
using Data.Repositories.Contracts;
using Services.CustomExceptions;
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

        public async Task<Book> GetByIdAsync(Guid id)
        {
            return await _booksRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _booksRepository.GetAllAsync(x => true);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            book.Id = await _booksRepository.AddAsync(book);
            return book;
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            await _booksRepository.UpdateAsync(book);
            return book;
        }

        public async Task<Book> DeleteBookAsync(Guid id)
        {
            var book = await GetByIdAsync(id);
            if (book == null)
            {
                throw new BookNotFoundException($"Book with {id} not found");
            }
            await _booksRepository.RemoveAsync(id);
            return book;
        }
    }
}
