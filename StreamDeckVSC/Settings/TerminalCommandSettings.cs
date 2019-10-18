using Newtonsoft.Json;

namespace StreamDeckVSC.Settings
{
    public class TerminalCommandSettings : KeySettings
    {
        [JsonProperty("command")]
        public string Command { get; set; }
    }
}
