namespace EventBusPatternDemo
{
	public class UserNotificationHandler
	{
		public UserNotificationHandler(IEventBus eventBus)
		{
			eventBus.Subscribe<UserCreatedEvent>(HandleUserCreated);
			Console.WriteLine("UserNotificationHandler is subscribed to UserCreatedEvent.");
		}

		// Символ @ перед именем переменной в C# используется для того, чтобы указать,
		// что переменная использует зарезервированное слово в качестве имени.
		// Если вы не хотите использовать @, просто переименуйте параметр в другое имя, например: userCreatedEvent (это лучше)
		private void HandleUserCreated(UserCreatedEvent @event)
		{
			Console.WriteLine($"New user created: {@event.UserName} (ID: {@event.UserId})");
			// Здесь можно отправить уведомление, записать лог и т.д.
		}
	}

}
