using Microsoft.EntityFrameworkCore;

namespace BookApp.Data
{
    public class BookDataDbContext : DbContext
    {
        public BookDataDbContext(DbContextOptions<BookDataDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
