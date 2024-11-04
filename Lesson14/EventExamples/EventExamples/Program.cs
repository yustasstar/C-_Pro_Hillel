// 1. Что такое события в C#

// - События(events) представляют собой способ взаимодействия между объектами. 
//	 Они позволяют одному объекту (инициатору события) уведомлять других (подписчиков) о том, что произошло какое-либо действие.
// - События основаны на делегатах, которые определяют сигнатуру методов, используемых для обработки событий.
// - События реализуют принцип "подписка-оповещение": подписчики "подписываются" на событие, а инициатор "оповещает" их,
//	 когда событие происходит.

// 2. Создание события

// Для создания события необходимо:
// - Определить делегат, который будет представлять сигнатуру обработчиков события.
// - Создать событие, используя ключевое слово event и тип делегата.
// - Использовать метод, который вызывает событие, проверяя, есть ли у него подписчики (обычно через ?.Invoke()).

//public delegate void MyEventHandler(object sender, EventArgs e);
//public event MyEventHandler MyEvent;

// 3. Подписка на событие

// - Для того чтобы объект мог реагировать на событие, он должен подписаться на него.
// - Подписка осуществляется с помощью оператора +=, а обработчик события — это метод с соответствующей сигнатурой делегата.

// myEventSource.MyEvent += MyEventHandlerMethod;

// 4. Отписка от события

// - Чтобы отписаться от события, используется оператор -=.
// - Это важно для предотвращения утечек памяти, так как подписчик продолжает существовать в памяти, пока подписан на событие.

// myEventSource.MyEvent -= MyEventHandlerMethod;

// Особенности и важные моменты

// - Проверка на null: Перед вызовом события рекомендуется проверять, есть ли подписчики (event?.Invoke()), чтобы избежать ошибок.
// - События могут вызываться только в пределах класса: События защищены от вызова извне.
//	 Их может вызывать только класс, который их объявил. Это помогает сохранить инкапсуляцию.
// - Использование EventHandler и EventArgs: В стандартной библиотеке C# часто используются EventHandler и EventArgs
//	 для стандартных событий. EventArgs можно унаследовать, чтобы передавать дополнительные данные в обработчик события.
// - Multicast-делегаты: Делегаты в C# мультикастовые, что позволяет иметь несколько подписчиков.
//	 Подписчики вызываются в порядке подписки. Если один из них вызывает исключение, последующие обработчики не вызываются.
// - Утечки памяти: Если объект подписался на событие и затем стал не нужен, но его не отписали от события,
//	 то этот объект не будет удален сборщиком мусора, что может привести к утечке памяти.
//	 Поэтому важно следить за отпиской объектов от событий, особенно в долгоживущих приложениях.

namespace EventExamples
{
	namespace FirstExample
	{
		public class Button
		{
			// Определяем делегат, который будет использоваться для события
			public delegate void ClickHandler(object sender, EventArgs e);

			// Создаем событие на основе делегата
			public event ClickHandler? OnClick;

			// Метод, вызывающий событие
			public void Click()
			{
				Console.WriteLine("Button was clicked!");

				// Проверка, есть ли подписчики, и вызов события
				OnClick?.Invoke(this, EventArgs.Empty);
			}
		}

		public class Subscriber
		{
			private string _name;

			public Subscriber(string name)
			{
				_name = name;
			}

			// Метод, который будет вызываться при возникновении события
			public void OnButtonClicked(object sender, EventArgs e)
			{
				Console.WriteLine($"{_name} received the click event.");
			}
		}

		public static class Test
		{
			public static void Start()
			{
				// Создаем кнопку
				Button button = new Button();

				// Создаем подписчиков
				Subscriber subscriber1 = new Subscriber("Subscriber 1");
				Subscriber subscriber2 = new Subscriber("Subscriber 2");

				// Подписываемся на событие
				button.OnClick += subscriber1.OnButtonClicked;
				button.OnClick += subscriber2.OnButtonClicked;

				// Имитируем нажатие на кнопку
				button.Click();

				// Отписка одного из подписчиков и повторное нажатие
				button.OnClick -= subscriber1.OnButtonClicked;
				button.Click();
			}
		}
	}

	namespace SecondExample
	{
		public class Button
		{
			public delegate void ClickHandler(object sender, EventArgs e);
			public event ClickHandler? OnClick;

			public void Click()
			{
				Console.WriteLine("Button was clicked!");
				OnClick?.Invoke(this, EventArgs.Empty);
			}
		}

		public class Subscriber : IDisposable
		{
			private Button _button;
			private bool _disposed = false;

			public Subscriber(Button button)
			{
				_button = button;

				// Подписка на событие
				_button.OnClick += HandleClick;
			}

			// Обработчик события
			private void HandleClick(object sender, EventArgs e)
			{
				Console.WriteLine("Subscriber received the click event.");
			}

			// Реализация IDisposable для отписки
			public void Dispose()
			{
				if (!_disposed)
				{
					// Отписка от события
					_button.OnClick -= HandleClick;
					_disposed = true;
					Console.WriteLine("Subscriber has been unsubscribed from the event.");
				}
			}
		}

		public static class Test
		{
			public static void Start()
			{
				Button button = new Button();

				// Создаем подписчика и подписываем его на событие
				using (Subscriber subscriber = new Subscriber(button))
				{
					button.Click();  // Вывод: "Button was clicked!" и "Subscriber received the click event."
				}

				// Здесь подписчик автоматически отписывается, так как вызван Dispose()
				button.Click();  // Вывод: "Button was clicked!" (но обработчик уже не вызывается)
			}
		}
	}

	public class Program
	{
		public async static Task Main()
		{
			// FirstExample.Test.Start();
			// SecondExample.Test.Start();

			////////////////////////////

			// В C# ссылки бывают сильными и слабыми, и эти понятия связаны с тем,
			// как сборщик мусора (Garbage Collector или GC) управляет памятью.

			// 1. Сильные ссылки(Strong References)
			//		- Сильная ссылка — это обычная ссылка на объект, удерживаемая переменной.
			//		  Пока существует хотя бы одна сильная ссылка на объект, этот объект не может быть удален сборщиком мусора.
			//		- Когда мы создаем объект с помощью оператора new, переменная получает сильную ссылку на этот объект.

			// Пример сильной ссылки:

			//	public class MyClass { }

			// public static void Main()
			// {
			//	MyClass obj = new MyClass(); // сильная ссылка
			//								 // Пока `obj` существует, объект `MyClass` в памяти тоже будет существовать.
			// }

			// 2. Слабые ссылки (Weak References)

			//	  - Слабая ссылка позволяет ссылаться на объект, не препятствуя его удалению сборщиком мусора.
			//		Если на объект существует только слабая ссылка, он может быть удален сборщиком мусора при следующем сборе.
			//	  - Слабая ссылка создается с помощью класса WeakReference.
			//	    Слабые ссылки полезны, когда нужно хранить кэш или объекты, которые легко восстановить или пересоздать.

			// Пример слабой ссылки:

			// public class MyClass { }

			// public static void Main()
			// {
			//	 MyClass strongRef = new MyClass();               // сильная ссылка
			//	 WeakReference weakRef = new WeakReference(strongRef); // слабая ссылка на `strongRef`

			//	 strongRef = null; // Убираем сильную ссылку

			//	 if (weakRef.IsAlive)
			//	 {
			//		MyClass obj = weakRef.Target as MyClass;
			//		Console.WriteLine("Объект ещё в памяти");
			//	 }
			//	 else
			//	 {
			//		Console.WriteLine("Объект удален сборщиком мусора");
			//	 }
			// }

			// Как отличить:

			// - Сильные ссылки держат объект в памяти, пока существуют, и GC их не удаляет.
			// - Слабые ссылки не удерживают объект в памяти, и GC удаляет объект, если нет других сильных ссылок.

			// Когда использовать слабые ссылки:

			// - Кэширование данных: Слабые ссылки полезны для объектов, которые можно восстановить или пересоздать,
			// если они удалены сборщиком мусора.
			// - Обработчики событий: В подписках на события использование слабых ссылок позволяет избежать утечек памяти,
			// так как обработчик может быть удален из памяти, если объект больше не используется.

			////////////////////////////////////////

			await WeatherForecast.Start();
		}
	}
}
