namespace ClassicControls
{
    /// <summary>
    /// Interaction logic for ImageList.xaml
    /// </summary>

    public partial class ImageList : System.Windows.Window
    {

        public ImageList()
        {
            InitializeComponent();
        }
        private void lst_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ListBox list = (ListBox)e.Source;
            StackPanel item = (StackPanel)list.SelectedItem;
            Label l = (Label)item.Children[1];
            MessageBox.Show(l.Content.ToString());
        }
    }
}