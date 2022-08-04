using Data.Data.Models;

namespace Services.Services.Contracts
{
    // add methods that can accept Expressions to make methods of repository useful
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task DeleteBookAsync(Book book);

    }
}
