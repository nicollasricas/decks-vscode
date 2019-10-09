using Fleck;
using Newtonsoft.Json;
using VSStreamDeck.Requests;

namespace VSStreamDeck
{
    public class Client
    {
        private readonly IWebSocketConnection socket;

        public Client(IWebSocketConnection socket) => this.socket = socket;

        public void Send(Request request) => socket.Send(JsonConvert.SerializeObject(request));

        public void Send(object data) => socket.Send(Serialize(new { id = data.GetType().Name, data = Serialize(data) }));

        private string Serialize(object data) => JsonConvert.SerializeObject(data);
    }
}
