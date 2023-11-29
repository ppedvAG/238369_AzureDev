using HalloBlazorServer.Model;
using Microsoft.EntityFrameworkCore;

namespace HalloBlazorServer.Data
{
    public class BooksContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Books_dev;Trusted_Connection=true;");
        }

    }
}
