using System.Security.Cryptography.X509Certificates;
using BookNest.Model;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Data
{
    public class BookDbContext: DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
            public DbSet<Book> Books { get; set; }
    }
}
