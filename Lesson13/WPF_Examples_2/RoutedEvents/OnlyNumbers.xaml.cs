namespace RoutedEvents
{
    /// <summary>
    /// Interaction logic for NoNumbers.xaml
    /// </summary>

    public partial class OnlyNumbers : System.Windows.Window
    {

        public OnlyNumbers()
        {
            InitializeComponent();
        }

        private void pnl_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            short val;
            if (!short.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }

        private void pnl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

    }
}