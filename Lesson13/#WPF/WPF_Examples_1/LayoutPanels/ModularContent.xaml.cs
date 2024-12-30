using System.Windows;
using System.Windows.Controls;

namespace LayoutPanels
{
	/// <summary>
	/// Interaction logic for ModularContent.xaml
	/// </summary>

	public partial class ModularContent : Window
	{

		public ModularContent()
		{
			InitializeComponent();

			AddHandler(System.Windows.Controls.Primitives.ToggleButton.CheckedEvent, new RoutedEventHandler(chk_Checked));
			AddHandler(System.Windows.Controls.Primitives.ToggleButton.UncheckedEvent, new RoutedEventHandler(chk_Unchecked));
		}

		private void chk_Checked(object sender, RoutedEventArgs e)
		{
			CheckBox chk = (CheckBox)e.OriginalSource;
			DependencyObject obj = LogicalTreeHelper.FindLogicalNode(this, chk.Content.ToString());
			((FrameworkElement)obj).Visibility = Visibility.Visible;
		}

		private void chk_Unchecked(object sender, RoutedEventArgs e)
		{
			CheckBox chk = (CheckBox)e.OriginalSource;
			DependencyObject obj = LogicalTreeHelper.FindLogicalNode(this, chk.Content.ToString());
			((FrameworkElement)obj).Visibility = Visibility.Collapsed;
		}
	}
}