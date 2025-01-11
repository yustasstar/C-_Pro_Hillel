namespace EventBusPatternDemo
{
	public class EventBus : IEventBus
	{
		private readonly Dictionary<Type, List<Delegate>> _handlers = [];

		public void Publish<TEvent>(TEvent @event)
		{
			if (_handlers.TryGetValue(typeof(TEvent), out var handlers))
			{
				foreach (var handler in handlers)
				{
					((Action<TEvent>)handler)(@event);
				}
			}
		}

		public void Subscribe<TEvent>(Action<TEvent> handler)
		{
			if (!_handlers.ContainsKey(typeof(TEvent)))
			{
				_handlers[typeof(TEvent)] = [];
			}
			_handlers[typeof(TEvent)].Add(handler);
		}
	}

}
