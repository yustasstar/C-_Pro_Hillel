using System.Windows;
using System.Windows.Controls;

namespace LayoutPanels
{
	/// <summary>
	/// Interaction logic for SimpleCanvas.xaml
	/// </summary>

	public partial class SimpleCanvas : Window
	{

		public SimpleCanvas()
		{
			InitializeComponent();
		}

		private void btn1_Click(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(btn1, 1);
			Panel.SetZIndex(btn2, 0);
		}

		private void btn2_Click(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(btn1, 0);
			Panel.SetZIndex(btn2, 1);
		}
	}
}