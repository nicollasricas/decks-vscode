using System;
using System.Collections.Generic;
using Fleck;
using Newtonsoft.Json;
using VSCodeStreamDeck.Messages;

namespace VSCodeStreamDeck
{
    public class MessageServer : IDisposable
    {
        private readonly WebSocketServer server;

        private static readonly Dictionary<Guid, Client> clients = new Dictionary<Guid, Client>();

        public static Client CurrentClient { get; private set; }

        public MessageServer(string host, int port) => server = new WebSocketServer($"ws://{host}:{port}");

        public void Start()
        {
            server.Start(connection =>
            {
                connection.OnOpen = () => OnConnected(connection);
                connection.OnClose = () => OnDisconnected(connection);
                connection.OnMessage = message => HandleMessages(connection, message);
            });
        }

        private void OnDisconnected(IWebSocketConnection connection) => clients.Remove(connection.ConnectionInfo.Id);

        private void OnConnected(IWebSocketConnection connection) => clients[connection.ConnectionInfo.Id] = new Client(connection);

        private void HandleMessages(IWebSocketConnection connection, string message)
        {
            var messageJSON = JsonConvert.DeserializeObject<Message>(message);

            if (messageJSON?.Id == ChangeSessionMessage.Id)
            {
                CurrentClient = clients[connection.ConnectionInfo.Id];
            }
        }

        public void Dispose() => server?.Dispose();
    }
}
