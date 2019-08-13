using Fleck;
using Newtonsoft.Json;
using VSCodeStreamDeck.Requests;

namespace VSCodeStreamDeck
{
    public class VSClient
    {
        private readonly IWebSocketConnection socket;

        public VSClient(IWebSocketConnection socket) => this.socket = socket;

        public void Send(Request request) => socket.Send(JsonConvert.SerializeObject(request));
    }
}
