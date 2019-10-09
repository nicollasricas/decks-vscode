using Newtonsoft.Json;

namespace VSStreamDeck.Messages
{
    [JsonObject]
    public class Message
    {
        public string Id { get; set; }

        public string Data { get; set; }
    }
}
