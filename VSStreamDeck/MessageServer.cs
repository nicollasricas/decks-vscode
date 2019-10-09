using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BarRaider.SdTools;
using Fleck;
using Newtonsoft.Json;
using VSStreamDeck.Messages;
using VSStreamDeck.Requests;

namespace VSStreamDeck
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

        private void HandleMessages(IWebSocketConnection connection, string rawMessage)
        {
            var messageFingerprint = JsonConvert.DeserializeObject<Message>(rawMessage);

            if(messageFingerprint != null)
            {
                var messageType = Type.GetType(messageFingerprint.Id) ?? throw new InvalidOperationException();

                var messageData = JsonConvert.DeserializeObject(messageFingerprint.Data, messageType);

                switch(messageData)
                {
                    case ChangeActiveSessionMessage changeSession when messageData is ChangeActiveSessionMessage:
                        SetCurrentClient(connection.ConnectionInfo.Id, changeSession.SessionId);
                        break;
                }
            }
        }

        private void SetCurrentClient(Guid clientId, string sessionId)
        {
            CurrentClient = clients[clientId];

            var activeSessionChanged = new ActiveSessionChangedMessage()
            {
                SessionId = sessionId
            };

            foreach(var client in clients)
            {
                if(client.Key == clientId)
                {
                    continue;
                }

                client.Value.Send(activeSessionChanged);
            }
        }

        public void Dispose() => server?.Dispose();
    }
}
