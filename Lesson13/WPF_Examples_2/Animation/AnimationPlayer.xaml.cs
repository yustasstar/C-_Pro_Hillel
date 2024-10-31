namespace Animation
{
    /// <summary>
    /// Interaction logic for AnimationPlayer.xaml
    /// </summary>

    public partial class AnimationPlayer : System.Windows.Window
    {

        public AnimationPlayer()
        {
            InitializeComponent();
        }

        private void storyboard_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            // Sender is the clock that was created for this storyboard.
            Clock storyboardClock = (Clock)sender;

            if (storyboardClock.CurrentProgress == null)
            {
                lblTime.Text = "[[ stopped ]]";
                progressBar.Value = 0;
            }
            else
            {
                lblTime.Text = storyboardClock.CurrentTime.ToString();
                progressBar.Value = (double)storyboardClock.CurrentProgress;
            }
        }

        private void sldSpeed_ValueChanged(object sender, RoutedEventArgs e)
        {
            fadeStoryboard.SetSpeedRatio(this, sldSpeed.Value);
        }
    }
}