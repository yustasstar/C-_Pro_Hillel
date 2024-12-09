using EfCoreExamples.ContextV2.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreExamples.ContextV2
{
	public class DbInitializer
	{
		private readonly ModelBuilder _modelBuilder;

		public DbInitializer(ModelBuilder modelBuilder)
		{
			_modelBuilder = modelBuilder;
		}

		public void Seed()
		{
			_modelBuilder.Entity<Category>(x =>
			{
				x.HasData(new Category
				{
					Id = 1,
					Name = "Mobile Phones 2",
					Description = "SmartPhones 2"
				});
				x.HasData(new Category
				{
					Id = 2,
					Name = "Tablets 2",
					Description = "Modern tablets 2"
				});
				x.HasData(new Category
				{
					Id = 3,
					Name = "Laptops 2",
					Description = "Modern laptops 2"
				});
			});
		}
	}
}
