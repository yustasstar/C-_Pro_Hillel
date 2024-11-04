namespace Share
{
    public abstract class SocketClient : SocketCommon
    {
        public abstract bool Connect(string serverHost, string port);
        public abstract void Disconnect();
        public abstract void Send(string message);
    }
}
