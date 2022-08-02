using Data.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.EF
{
    internal sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; }
    }
}
