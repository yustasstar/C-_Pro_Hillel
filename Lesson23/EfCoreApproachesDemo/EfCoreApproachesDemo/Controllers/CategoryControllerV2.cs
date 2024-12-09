using EfCoreExamples.ContextV1;
using EfCoreExamples.ContextV2;
using EfCoreExamples.ContextV2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreExamples.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryControllerV2 : ControllerBase
	{
		private readonly SecondInternetShopDbContext _secondInternetShopDbContext;

		public CategoryControllerV2(SecondInternetShopDbContext secondInternetShopDbContext) {
			_secondInternetShopDbContext = secondInternetShopDbContext;
		}

		[HttpPost]
		public async Task<IActionResult> GetCategoryAdd(CancellationToken token)
		{
			var cat = new Category
			{
				Name = "second",
				Description = "desc second"
			};

			_secondInternetShopDbContext.Add(cat);

			await _secondInternetShopDbContext.SaveChangesAsync(token);

			return StatusCode(StatusCodes.Status200OK);
		}

		[HttpGet]
		public async Task<IActionResult> GetCategories(CancellationToken token)
		{
			var categories = await _secondInternetShopDbContext.Categories.ToListAsync(token);
			if (categories == null)
			{
				return StatusCode(StatusCodes.Status204NoContent, "No categories in database.");
			}

			return StatusCode(StatusCodes.Status200OK, categories);
		}
	}
}
