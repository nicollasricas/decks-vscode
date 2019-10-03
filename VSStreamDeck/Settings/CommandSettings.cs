using Newtonsoft.Json;

namespace VSCodeStreamDeck.Settings
{
    public class CommandSettings : KeySettings
    {
        [JsonProperty("command")]
        public string Command { get; set; }

        [JsonProperty("arguments")]
        public string Arguments { get; set; }
    }
}
