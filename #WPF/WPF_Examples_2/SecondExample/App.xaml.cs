using SecondExample.Models;
using SecondExample.ViewModels;
using SecondExample.Views;
using System.Windows;

namespace SecondExample
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void OnStartup(object sender, StartupEventArgs e)
		{
			List<Book> books =
			[
				new Book("Demo book 1", null, 3),
				new Book("Demo book 2", "Demo Author 1", 1),
				new Book("Demo book 3", "Demo Author 2", 2)
			];

			MainView view = new(); // создали View
			MainViewModel viewModel = new(books); // Создали ViewModel
			view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
			view.Show();
		}
	}
}
