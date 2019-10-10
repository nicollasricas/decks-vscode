using Newtonsoft.Json;

namespace VSStreamDeck.Settings
{
    public class ExecuteCommandSettings : KeySettings
    {
        [JsonProperty("command")]
        public string Command { get; set; }

        //[JsonProperty("arguments")]
        //public string Arguments { get; set; }
    }
}
