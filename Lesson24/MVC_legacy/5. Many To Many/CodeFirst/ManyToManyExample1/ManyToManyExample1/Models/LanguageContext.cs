using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ManyToManyExample1.Models
{
    public class LanguageContext : DbContext
    {
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Language> Languages { get; set; }

        public LanguageContext()
            : base("DefaultConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Continent>().HasMany(c => c.Languages)
                .WithMany(s => s.Continents)
                .Map(t => t.MapLeftKey("ContinentId")
                .MapRightKey("LanguageId")
                .ToTable("ContinentLanguage"));
        }
    }
}