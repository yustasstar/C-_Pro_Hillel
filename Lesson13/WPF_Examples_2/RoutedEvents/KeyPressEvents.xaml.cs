namespace RoutedEvents
{
    /// <summary>
    /// Interaction logic for KeyPressEvents.xaml
    /// </summary>

    public partial class KeyPressEvents : Window
    {

        public KeyPressEvents()
        {
            InitializeComponent();
        }

        private void KeyEvent(object sender, KeyEventArgs e)
        {

            string message = "Event: " + e.RoutedEvent + " " +
                " Key: " + e.Key;
            lstMessages.Items.Add(message);
        }

        private new void TextInput(object sender, TextCompositionEventArgs e)
        {
            string message = "Event: " + e.RoutedEvent + " " +
                " Text: " + e.Text;
            lstMessages.Items.Add(message);
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            string message =
                "Event: " + e.RoutedEvent;
            lstMessages.Items.Add(message);
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            lstMessages.Items.Clear();
        }
    }
}