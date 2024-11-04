using System.Windows;

namespace SynchronizationContextDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly SynchronizationContext _uiContext;

		public MainWindow()
		{
			InitializeComponent();
			_uiContext = SynchronizationContext.Current;
		}

		private async void StartWithSyncButton_Click(object sender, RoutedEventArgs e)
		{
			// Simulate some time-consuming work on a background thread
			await Task.Run(() =>
			{
				Thread.Sleep(2000); // Simulate work
				var result = CalculateSomething();
				// Update UI on the main (UI) thread (not in current thread)
				_uiContext.Post(state => UpdateUi(result), null);
			});
		}

		private async void StartWithDispatchButton_Click(object sender, RoutedEventArgs e)
		{
			// Simulate some time-consuming work on a background thread
			await Task.Run(() =>
			{
				Thread.Sleep(2000); // Simulate work
				var result = CalculateSomething();
				// Update UI on the main (UI) thread (not in current thread)
				Dispatcher.Invoke(() => UpdateUi(result));
			});
		}

		private async void StartWithoutSyncOrDispatchButton_Click(object sender, RoutedEventArgs e)
		{
			// Simulate some time-consuming work on a background thread
			await Task.Run(() =>
			{
				Thread.Sleep(2000); // Simulate work
				var result = CalculateSomething();
				// Этот вариант функции вызывает ошибку из-за того,
				// что мы пытаемся обновить пользовательский интерфейс(UI) из фонового потока напрямую,
				// без использования SynchronizationContext
				// Проблема заключается в том, что обновление пользовательского интерфейса
				// должно выполняться на главном(UI) потоке.
				// В приведенном коде мы обращаемся к элементам управления WPF из фонового потока,
				// что может вызвать исключение.
				UpdateUi(result);
			});
		}

		private int CalculateSomething()
		{
			// Simulate a long calculation
			Thread.Sleep(1000);
			return new Random().Next(100, 999);
		}

		private void UpdateUi(int result)
		{
			// This method runs on the UI thread
			ResultLabel.Content = $"Result: {result}";
		}
	}
}
