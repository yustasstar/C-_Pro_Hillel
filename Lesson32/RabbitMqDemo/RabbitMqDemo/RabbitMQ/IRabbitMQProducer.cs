namespace RabbitMqDemo.RabbitMQ
{
	public interface IRabbitMQProducer
	{
		public void SendProductMessage<T>(T message);
	}
}
