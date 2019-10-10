using Newtonsoft.Json;

namespace VSStreamDeck.Messages
{
    public class ChangeActiveSessionMessage
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }
}
