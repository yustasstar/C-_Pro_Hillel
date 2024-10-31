namespace ClassicControls
{
    /// <summary>
    /// Interaction logic for SliderTest.xaml
    /// </summary>

    public partial class SliderTest : System.Windows.Window
    {

        public SliderTest()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider obj = (Slider)sender;
            this.Title = obj.Value.ToString();
        }

    }
}