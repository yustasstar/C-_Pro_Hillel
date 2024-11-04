namespace Share
{
    public abstract class SocketServer : SocketCommon
    {
        public abstract void Start(string port);
        public abstract void Stop();
        public abstract void SendToClients(string message);
    }
}
