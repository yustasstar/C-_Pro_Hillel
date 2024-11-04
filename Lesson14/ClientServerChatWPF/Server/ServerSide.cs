using Share;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class ServerSide : SocketServer
    {
        public AsyncCallback? workerCallback;

        private Socket? controlSocket;
        private Dictionary<string, Socket> workerSocketList = new();

        public override void Start(string port)
        {
            try
            {
                Log("Starting on port " + port);
                controlSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var ipLocal = new IPEndPoint(IPAddress.Any, int.Parse(port));
                controlSocket.Bind(ipLocal);
                controlSocket.Listen(4);
                controlSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);
                Log("Started!");
            }
            catch (SocketException error)
            {
                Log("Socket exception: " + error.ErrorCode + ": " + error.Message);
            }
        }

        public override void Stop()
        {
            Log("Server stopping...");
            controlSocket?.Close();
            controlSocket = null;

            foreach (var item in workerSocketList)
            {
                CloseClientConnection(item.Value);
                Log(item.Key + " shut down!");
            }

            workerSocketList.Clear();
            Log("Server stopped!");
        }

        public override void SendToClients(string message)
        {
            Log("Broadcasting /" + message + "/");

            foreach (var item in workerSocketList)
            {
                SendToClient(item.Value, message);
                Log("Message: " + message);
            }

            Log("Broadcasting finished!");
        }

        public void OnClientConnect(IAsyncResult asyncResult)
        {
            if (controlSocket == null)
                return;

            try
            {
                var connectingClient = controlSocket.EndAccept(asyncResult);
                var clientEndpoint = connectingClient.RemoteEndPoint as IPEndPoint;
                workerSocketList.Add(AddLogHeader(clientEndpoint), connectingClient);
                WaitForData(connectingClient);
                Log(AddLogHeader(clientEndpoint) + "client connected!");
                controlSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);
            }
            catch (SocketException error)
            {
                Log("Socket exception: " + error.ErrorCode + ": " + error.Message);
            }
        }

        public void WaitForData(Socket socket)
        {
            try
            {
                workerCallback ??= new AsyncCallback(OnDataReceived);

                SocketPacket packet = new()
                {
                    currentSocket = socket
                };
                socket.BeginReceive(packet.dataBuffer, 0, packet.dataBuffer.Length, SocketFlags.None, workerCallback, packet);
            }
            catch (SocketException error)
            {
                Log("Socket exception: " + error.ErrorCode + ": " + error.Message);
            }
        }

        public void OnDataReceived(IAsyncResult? asyncResult)
        {
            if (controlSocket == null)
                return;

            SocketPacket? packet;
            IPEndPoint? client;

            try
            {
                packet = asyncResult?.AsyncState as SocketPacket;
                client = packet?.currentSocket?.RemoteEndPoint as IPEndPoint;
                int receiveCount = packet.currentSocket.EndReceive(asyncResult);

                if(receiveCount == 0)
                {
                    RemoveClient(client);
                }
                else
                {
                    var message = Encoding.UTF8.GetString(packet.dataBuffer, 0, receiveCount);
                    Log(AddLogHeader(client) + "\"" +  message + "\"");
                    WaitForData(packet.currentSocket);
                }
            }
            catch (SocketException error)
            {
                if(error.ErrorCode == 10054)
                {
                    packet = asyncResult?.AsyncState as SocketPacket;
                    client = packet?.currentSocket?.RemoteEndPoint as IPEndPoint;
                    RemoveClient(client);
                }
                else
                {
                    Log("Socket exception: " + error.ErrorCode + ": " + error.Message);
                }
            }
        }

        protected void RemoveClient(IPEndPoint client)
        {
            if (workerSocketList.ContainsKey(AddLogHeader(client)))
            {
                var clientSocket = workerSocketList[AddLogHeader(client)];
                CloseClientConnection(clientSocket);
                workerSocketList.Remove(AddLogHeader(client));
            }

            Log(AddLogHeader(client) + "client disconnected!");
        }

        protected static void CloseClientConnection(Socket clientSocket)
        {
            clientSocket?.Close();
        }

        protected void SendToClient(Socket clientSocket, string message)
        {
            if (clientSocket == null)
                return;

            try
            {
                var dataBuffer = Encoding.UTF8.GetBytes(message);
                clientSocket.Send(dataBuffer);
            }
            catch (SocketException error)
            {
                Log("Socket exception: " + error.ErrorCode + ": " + error.Message);
            }
        }
    }
}
