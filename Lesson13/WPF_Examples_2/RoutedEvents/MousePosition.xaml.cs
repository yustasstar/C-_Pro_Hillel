using System.Windows;
using System.Windows.Input;

namespace RoutedEvents
{
	/// <summary>
	/// Interaction logic for MousePosition.xaml
	/// </summary>

	public partial class MousePosition : System.Windows.Window
	{

		public MousePosition()
		{
			InitializeComponent();
		}

		private void MouseMoved(object sender, MouseEventArgs e)
		{
			Point pt = e.GetPosition(this);
			lblInfo.Text =
				string.Format("You are at ({0},{1}) in window coordinates",
				pt.X, pt.Y);
		}

	}
}