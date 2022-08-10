using Data.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.EF
{
    internal sealed class ApplicationContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Book> Books { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
