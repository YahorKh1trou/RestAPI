using Data.Data.Models;

namespace Services.Services.Contracts
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetAsync();
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetByNameAsync(string bookname);
        Task<IEnumerable<Book>> GetByAuthorAsync(string lastname);
        Task<IEnumerable<Book>> GetAllByIdAsync(IEnumerable<int> bookIds);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task<Book> DeleteBookAsync(int id);

    }
}
