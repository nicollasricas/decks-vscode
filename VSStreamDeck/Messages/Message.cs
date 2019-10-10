using Newtonsoft.Json;

namespace VSStreamDeck.Messages
{
    [JsonObject]
    public class Message
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}