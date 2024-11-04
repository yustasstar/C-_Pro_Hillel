using System.Windows;

namespace Server
{
    public partial class MainWindow : Window
    {
        private readonly ServerSide server;

        public MainWindow()
        {
            InitializeComponent();
            server = new ServerSide
            {
                logFunction = UpdateLog
            };
            MesServer.IsEnabled = false;
            SendServer.IsEnabled = false;
            Port.IsEnabled = true;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            StartServer();
            MesServer.IsEnabled = true;
            SendServer.IsEnabled = true;
            Port.IsEnabled = false;
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            StopServer();
            MesServer.IsEnabled = false;
            SendServer.IsEnabled = false;
            Port.IsEnabled = true;
        }

        private void SendServer_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void StartServer()
        {
            server.Start(Port.Text);
        }

        private void StopServer()
        {
            server.Stop();
        }

        private void SendMessage()
        {
            server.SendToClients(MesServer.Text);
            MesServer.Text = string.Empty;
        }

        private void UpdateLog(string s)
        {
            ServerLog.Items.Add(s);
        }
    }
}
