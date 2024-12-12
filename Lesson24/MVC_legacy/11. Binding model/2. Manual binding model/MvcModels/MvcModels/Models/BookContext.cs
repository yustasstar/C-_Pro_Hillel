using System.Data.Entity;

namespace MvcModels.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}