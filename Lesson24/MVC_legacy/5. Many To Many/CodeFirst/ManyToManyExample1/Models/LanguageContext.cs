using System.Data.Entity;

namespace ManyToManyExample1.Models
{
    public class LanguageContext : DbContext
    {
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}