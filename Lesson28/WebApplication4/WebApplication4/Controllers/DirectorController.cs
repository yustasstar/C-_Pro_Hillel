using Microsoft.AspNetCore.Mvc;
using WebApplication4.Repositories.Interfaces;

namespace WebApplication4.Controllers
{
	public class DirectorController : Controller
	{
		private readonly IDirectorRepository _directorRepository;

		public DirectorController(IDirectorRepository directorRepository)
		{
			_directorRepository = directorRepository;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _directorRepository.GetDirectors());
		}
	}
}
