namespace WpfRoutedEvents
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

        private void WindowPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox.Text += "Window Preview Mouse Down" + Environment.NewLine;
            // e.Handled = true;
        }

        private void GridPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox.Text += "Grid Preview Mouse Down" + Environment.NewLine;
            // e.Handled = true;
        }

        private void SPPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox.Text += "Stack Preview Mouse Down" + Environment.NewLine;
            // e.Handled = true;
        }

        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox.Text += "Window Mouse Down" + Environment.NewLine;
            // e.Handled = true;
        }

        private void GridMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox.Text += "Grid Mouse Down" + Environment.NewLine;
            // e.Handled = true;
        }

        private void StackPanelMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox.Text += "Stack Panel Mouse Down" + Environment.NewLine;
            // e.Handled = true;
        }
    }
}