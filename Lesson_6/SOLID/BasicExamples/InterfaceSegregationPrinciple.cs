namespace Lesson6.SOLID.BasicExamples
{
	// Problem:

	// Интерфейс слишком большой и содержит методы, которые не нужны некоторым классам.

	// Роботы не едят, и их вынуждают реализовывать ненужный метод, что нарушает принцип разделения интерфейсов.

	public interface IWorker
	{
		void Work();
		void Eat();
	}

	public class Robot : IWorker
	{
		public void Work()
		{
			// Логика работы робота
		}

		public void Eat()
		{
			throw new NotImplementedException();
		}
	}

	// Solution:

	// Разделим интерфейс на более маленькие и специфичные.

	public interface IWorkable
	{
		void Work();
	}

	public interface IEatable
	{
		void Eat();
	}

	public class HumanV2 : IWorkable, IEatable
	{
		public void Work()
		{
			// Логика работы человека
		}

		public void Eat()
		{
			// Логика еды
		}
	}

	public class RobotV2 : IWorkable
	{
		public void Work()
		{
			// Логика работы робота
		}
	}

	// Теперь каждый класс реализует только те интерфейсы, которые ему необходимы.
}
