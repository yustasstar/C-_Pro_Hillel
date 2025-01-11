using MassTransit;

namespace EventBusPatternDemo2
{
	public class UserCreatedEventConsumer : IConsumer<UserCreatedEvent>
	{
		public async Task Consume(ConsumeContext<UserCreatedEvent> context)
		{
			var @event = context.Message;
			Console.WriteLine($"Event received: New user created - {@event.UserName} (ID: {@event.UserId})");

			// Дополнительная логика обработки события
			await Task.CompletedTask;
		}
	}
}
