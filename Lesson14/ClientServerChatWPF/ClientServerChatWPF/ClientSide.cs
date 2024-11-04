using Share;
using System.Net.Sockets;
using System;
using System.Threading;
using System.Net;
using System.Text;

namespace Client
{
    public delegate void DisconnectUIDelegate();

    public class ClientSide : SocketClient
    {
        public AsyncCallback? clientCallBack;
        public Socket? clientSocket;
        public DisconnectUIDelegate? updateScreenAfterDisconnect;

        public override bool Connect(string serverHost, string port)
        {
            try {
                Log("connecting on /" + serverHost + ":" + port + "/");
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(serverHost);
                IPEndPoint ipEnd = new IPEndPoint(ip, int.Parse(port));
                clientSocket.Connect(ipEnd);
                if (clientSocket.Connected)
                {
                    Log(AddLogHeader(clientSocket.RemoteEndPoint as IPEndPoint) + "connected!");
                    WaitForData();
                }
                return true;
            } catch (SocketException se) {
                Log("Socket exception " + se.ErrorCode + " : " + se.Message);
            }
            return false;
        }

        public override void Disconnect()
        {
            if (clientSocket == null) 
                return;

            Log(AddLogHeader(clientSocket.RemoteEndPoint as IPEndPoint) + "disconnecting");
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            clientSocket = null;
            Log("disconnected!");
        }

        public override void Send(string message)
        {
            if (clientSocket == null)
                return;

            try
            {
                Log(AddLogHeader(clientSocket.RemoteEndPoint as IPEndPoint) + "send - \"" + message + "\"");
                byte[] dataBuffer = Encoding.UTF8.GetBytes(message);
                clientSocket.Send(dataBuffer);
            }
            catch (SocketException se)
            {
                Log("SocketException " + se.ErrorCode + " : " + se.Message);
            }
        }

        public void WaitForData()
        {
            try
            {
                clientCallBack ??= new AsyncCallback(OnDataReceived);
                var theSocPkt = new SocketPacket
                {
                    currentSocket = clientSocket
                };
                clientSocket?.BeginReceive(theSocPkt.dataBuffer, 0, theSocPkt.dataBuffer.Length, SocketFlags.None, clientCallBack, theSocPkt);
            }
            catch (SocketException error)
            {
                Log("Socket exception " + error.ErrorCode + " : " + error.Message);
            }
        }

        public void OnDataReceived(IAsyncResult asyncResult)
        {
            SocketPacket? socketData;
            if (clientSocket == null) 
                return;

            try
            {
                socketData = asyncResult.AsyncState as SocketPacket;
                int receiveCount = socketData!.currentSocket!.EndReceive(asyncResult);

                if (receiveCount == 0)
                {
                    ClientStop();
                }
                else
                {
                    string message = Encoding.UTF8.GetString(socketData.dataBuffer, 0, receiveCount);
                    Log(AddLogHeader(clientSocket.RemoteEndPoint as IPEndPoint) + "receive - \"" + message + "\"");
                    WaitForData();
                }

            }
            catch (SocketException error)
            {
                if (error.ErrorCode == 10054)
                {
                    ClientStop();
                }
                else
                {
                    Log("SocketException " + error.ErrorCode + " : " + error.Message);
                }
            }
        }

        protected void ClientStop()
        {
            clientSocket = null;

            if (updateScreenAfterDisconnect != null)
            {
                if (syncContext == SynchronizationContext.Current)
                {
                    updateScreenAfterDisconnect();
                }
                else
                {
                    syncContext?.Post(o => updateScreenAfterDisconnect(), null);
                }
            }
            Log("Server disconnected!");
        }
    }
}
