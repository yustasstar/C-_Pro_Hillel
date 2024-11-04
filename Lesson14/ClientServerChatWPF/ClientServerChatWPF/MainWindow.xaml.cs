using Client;
using System.Windows;

namespace ClientServerChatWPF
{
    public partial class MainWindow : Window
    {
        private readonly ClientSide client;

        public MainWindow()
        {
            InitializeComponent();
            client = new ClientSide
            {
                logFunction = UpdateLog,
                updateScreenAfterDisconnect = UpdateDisconnect
            };
            Port.IsEnabled = true;
            IP.IsEnabled = true;
            MesClient.IsEnabled = false;
            SendClient.IsEnabled = false;
            DisConnect.IsEnabled = false;
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            if (ConnectClient())
            {
                Port.IsEnabled = false;
                IP.IsEnabled = false;
                MesClient.IsEnabled = true;
                Connect.IsEnabled = false;
                DisConnect.IsEnabled = true;
                SendClient.IsEnabled = true;
            }
        }

        private void DisConnect_Click(object sender, RoutedEventArgs e)
        {
            DisconnectClient();
            UpdateDisconnect();
            DisConnect.IsEnabled = false;
            Connect.IsEnabled = true;
        }

        private void SendClient_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private bool ConnectClient()
        {
            return client.Connect(IP.Text, Port.Text);
        }

        private void DisconnectClient()
        {
            client.Disconnect();
        }

        private void SendMessage()
        {
            client.Send(MesClient.Text);
            MesClient.Text = string.Empty;
        }

        private void UpdateDisconnect()
        {
            Port.IsEnabled = true;
            IP.IsEnabled = true;
            MesClient.IsEnabled = false;
            SendClient.IsEnabled = false;
        }

        private void UpdateLog(string s)
        {
            ClientLog.Items.Add(s);
        }
    }
}
