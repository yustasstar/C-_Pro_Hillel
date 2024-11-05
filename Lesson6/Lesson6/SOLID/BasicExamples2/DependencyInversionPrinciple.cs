namespace Lesson6.SOLID.BasicExamples2
{
	//Принцип інверсії залежностей(Dependency Inversion Principle) служить для створення слабко пов'язаних сутностей,
	//які легко тестувати, модифікувати та оновлювати. Цей принцип можна сформулювати так:

	//Модулі верхнього рівня повинні залежати від модулів нижнього рівня.
	//І ті, й інші повинні залежати від абстракцій.

	//Абстракції не повинні залежати від деталей.
	//Деталі мають залежати від абстракцій.

	public interface IMessanger
	{
		void Send();
	}

	public class Email : IMessanger
	{
		public void Send() { }
	}

	public class Sms : IMessanger
	{
		public void Send() { }
	}

	public class Notification
	{
		private IMessanger _messanger;

		public Notification(IMessanger messanger)
		{
			_messanger = messanger;
		}

		public void Send()
		{
			_messanger.Send();
		}
	}

	public static class DependencyInversionPrincipleDemo
	{
		public static void Demo()
		{
			IMessanger emailMessanger = new Email();
			IMessanger smsMessanger = new Sms();
			Notification notification1 = new Notification(emailMessanger);
			notification1.Send();
			Notification notification2 = new Notification(smsMessanger);
			notification2.Send();
		}
	}
}

