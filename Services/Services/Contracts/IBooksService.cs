using Data.Data.Models;

namespace Services.Services.Contracts
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetAsync();
        Task<Book> GetByIdAsync(Guid id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task<Book> DeleteBookAsync(Guid id);

    }
}
