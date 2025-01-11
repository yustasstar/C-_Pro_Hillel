﻿namespace EventBusPatternDemo
{
	public interface IEventBus
	{
		void Publish<TEvent>(TEvent @event);
		void Subscribe<TEvent>(Action<TEvent> handler);
	}
}
