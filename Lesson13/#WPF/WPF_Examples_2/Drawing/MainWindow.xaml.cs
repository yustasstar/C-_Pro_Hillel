using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Drawing
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ButtonClick(object sender, RoutedEventArgs e)
		{
			// Get the current button.
			Button cmd = (Button)e.OriginalSource;

			// Create an instance of the window named
			// by the current button.
			Type type = this.GetType();
			Assembly assembly = type.Assembly;
			Window win = (Window)assembly.CreateInstance(
				type.Namespace + "." + cmd.Content);

			// Show the window.
			win.ShowDialog();
		}
	}
}