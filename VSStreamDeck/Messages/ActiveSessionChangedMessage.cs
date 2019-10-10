using Newtonsoft.Json;

namespace VSStreamDeck.Messages
{
    public class ActiveSessionChangedMessage
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        public ActiveSessionChangedMessage()
        {
        }

        public ActiveSessionChangedMessage(string sessionId) => SessionId = sessionId;
    }
}
