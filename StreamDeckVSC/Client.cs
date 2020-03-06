using Fleck;
using Newtonsoft.Json;
using StreamDeckVSC.Messages;

namespace StreamDeckVSC
{
    public class Client
    {
        private readonly IWebSocketConnection socket;

        public IWebSocketConnection Connection => socket;

        public Client(IWebSocketConnection socket) => this.socket = socket;

        public void Send(object data) => socket.Send(Serialize(new Message { Id = data.GetType().Name, Data = Serialize(data) }));

        private string Serialize(object data) => JsonConvert.SerializeObject(data);
    }
}
