using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BindingToObject
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public User user = new User("Vasya");

		public MainWindow()
		{
			InitializeComponent();

			try
			{
				Binding bind = new Binding("UserName");
				bind.Source = user;
				bind.Mode = BindingMode.OneWay;
				bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

				textBlockOriginName.SetBinding(TextBlock.TextProperty, bind);


				Binding bind1 = new Binding("UserName");
				bind1.Source = user;
				bind1.Mode = BindingMode.TwoWay;
				bind1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

				textBoxNewName.SetBinding(TextBox.TextProperty, bind1);


			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}