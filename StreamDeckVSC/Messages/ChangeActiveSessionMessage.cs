using Newtonsoft.Json;

namespace StreamDeckVSC.Messages
{
    public class ChangeActiveSessionMessage
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }
}
