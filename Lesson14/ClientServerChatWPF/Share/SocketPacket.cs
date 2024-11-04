using System.Net.Sockets;

namespace Share
{
    public class SocketPacket
    {
        public Socket? currentSocket;
        public byte[] dataBuffer = new byte[1024];
    }
}
