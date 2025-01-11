using Microsoft.AspNetCore.Mvc;

namespace EventBusPatternDemo.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IEventBus _eventBus;

		public UsersController(IEventBus eventBus)
		{
			_eventBus = eventBus;
		}

		[HttpPost]
		public IActionResult CreateUser(string userName)
		{
			var userId = Guid.NewGuid().ToString();

			Console.WriteLine($"Publishing event for user: {userName} (ID: {userId})");

			// Публикация события
			_eventBus.Publish(new UserCreatedEvent
			{
				UserId = userId,
				UserName = userName
			});

			return Ok(new { UserId = userId });
		}
	}

}
