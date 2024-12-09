using EfCoreExamples.ContextV2.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreExamples.ContextV2
{
	public class SecondInternetShopDbContext : DbContext
	{
		public SecondInternetShopDbContext(DbContextOptions<SecondInternetShopDbContext> options) : base(options) { }

		public DbSet<Product> Products { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		// public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Manufacturer> Manufactures { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			new DbInitializer(modelBuilder).Seed();
		}
	}
}
