using Data.Data.EF;
using Data.Data.Models;
using Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    internal sealed class BooksRepository : IBooksRepository
    {
        private readonly ApplicationContext _db;

        public BooksRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Guid> AddAsync(Book book)
        {
            await _db.AddAsync(book);
            await _db.SaveChangesAsync();
            return book.Id;
        }

        public async Task<List<Book>> GetAllAsync(Expression<Func<Book, bool>> predicate)
            => await _db.Books.Where(predicate).ToListAsync();

        public async Task<Book> GetAsync(Guid id)
            => await _db.Books.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Book> GetAsync(Expression<Func<Book, bool>> predicate)
            => (await GetAllAsync(predicate)).FirstOrDefault();

        public async Task<Book> GetLastAsync(Expression<Func<Book, bool>> predicate)
            => (await GetAllAsync(predicate)).LastOrDefault();

        public async Task RemoveAsync(Guid id)
        {
            var book = await GetAsync(id);
            _db.Remove(book);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _db.Update(book);
            await _db.SaveChangesAsync();
        }
    }
}
