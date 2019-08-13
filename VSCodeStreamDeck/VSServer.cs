using System;
using System.Collections.Generic;
using BarRaider.SdTools;
using Fleck;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VSCodeStreamDeck.Messages;

namespace VSCodeStreamDeck
{
    class VSServer
    {
        private readonly WebSocketServer server;

        private static readonly Dictionary<Guid, VSClient> clients = new Dictionary<Guid, VSClient>();

        public static VSClient Current { get; private set; }

        public VSServer(string host, int port) => server = new WebSocketServer($"ws://{host}:{port}");

        public void Start()
        {
            //server.ListenerSocket.NoDelay = false;
            //server.RestartAfterListenError = true;

            server.Start(client =>
            {
                client.OnOpen = () => OnConnected(client);
                client.OnClose = () => OnDisconnected(client);
                client.OnMessage = message => HandleMessages(client, message);
            });
        }

        private void OnDisconnected(IWebSocketConnection client)
        {
            if (clients.ContainsKey(client.ConnectionInfo.Id))
            {
                clients.Remove(client.ConnectionInfo.Id);
            }
        }

        private void OnConnected(IWebSocketConnection client) => clients[client.ConnectionInfo.Id] = new VSClient(client);

        private void HandleMessages(IWebSocketConnection client, string message)
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, "Received message " + message);

            var messageJSON = JsonConvert.DeserializeObject<Message>(message);

            if (messageJSON?.Id == ChangeCurrentClientMessage.Id)
            {
                Current = clients[client.ConnectionInfo.Id];

                Logger.Instance?.LogMessage(TracingLevel.INFO, $"Changed current client, session id: {client.ConnectionInfo.Id}.");
            }
        }
    }
}
