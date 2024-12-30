using System.Windows;
using System.Windows.Controls;

namespace Example_1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			// Fill the list box with all the Button
			// styles.
			lstStyles.Items.Add("GrowingButtonStyle");
			lstStyles.Items.Add("TiltButton");
			lstStyles.Items.Add("BigGreenButton");
			lstStyles.Items.Add("BasicControlStyle");
		}

		private void comboStyles_Changed(object sender, SelectionChangedEventArgs e)
		{
			// Get the selected style name from the list box.     
			Style currStyle = (Style)
			  TryFindResource(lstStyles.SelectedValue);

			if (currStyle != null)
			{
				// Set the style of the button type.
				btnStyle.Style = currStyle;
			}
		}
	}
}