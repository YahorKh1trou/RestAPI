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

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _booksRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Book>> GetByNameAsync(string bookname)
        {
            return await _booksRepository.GetByNameAsync(bookname);
        }

        public async Task<IEnumerable<Book>> GetByAuthorAsync(string lastname)
        {
            return await _booksRepository.GetByAuthorAsync(lastname);
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

        public async Task<Book> DeleteBookAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book == null)
            {
                throw new BookNotFoundException($"Book with {id} not found");
            }
            await _booksRepository.RemoveAsync(id);
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllByIdAsync(IEnumerable<int> bookIds)
        {
            var allBooks = await GetAsync();
            var foundBooks = from book in allBooks
                             join bookId in bookIds on book.Id equals bookId
                             select book;
            return (List<Book>)foundBooks;
        }
    }
}
