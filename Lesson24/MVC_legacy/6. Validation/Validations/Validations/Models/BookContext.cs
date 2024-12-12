using System.Data.Entity;

namespace Validations.Models
{
    public class BookContext : DbContext
    {
       public DbSet<Book> Books { get; set; }
    }
}