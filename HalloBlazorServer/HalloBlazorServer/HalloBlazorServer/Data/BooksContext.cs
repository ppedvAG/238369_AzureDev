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
            var localConString = "Server=(localdb)\\mssqllocaldb;Database=Books_dev;Trusted_Connection=true;";
            //var azureConstring = "Server=tcp:mydbserver666.database.windows.net,1433;Initial Catalog=mydb;Encrypt=True;TrustServerCertificate=False;Connection Timeout=10;Authentication='Active Directory Default'";
            var azureConstring = "Server=tcp:mydbserver666.database.windows.net,1433;Initial Catalog=mydb;Persist Security Info=False;User ID=Wilma;Password=IhrPasswort123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            optionsBuilder.UseSqlServer(azureConstring);
        }

    }
}
