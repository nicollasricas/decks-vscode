using Newtonsoft.Json;

namespace StreamDeckVSC.Settings
{
    public class ExecuteCommandSettings : KeySettings
    {
        [JsonProperty("command")]
        public string Command { get; set; }

        [JsonProperty("arguments")]
        public string Arguments { get; set; }
    }
}
