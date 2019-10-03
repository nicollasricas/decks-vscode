using Fleck;
using Newtonsoft.Json;
using VSCodeStreamDeck.Requests;

namespace VSCodeStreamDeck
{
    public class Client
    {
        private readonly IWebSocketConnection socket;

        public Client(IWebSocketConnection socket) => this.socket = socket;

        public void Send(Request request) => socket.Send(JsonConvert.SerializeObject(request));

        public void Send(string request) => socket.Send(request);
    }
}
