using Newtonsoft.Json;

namespace VSCodeStreamDeck.Settings
{
    public class TerminalCommandSettings : KeySettings
    {
        [JsonProperty("command")]
        public string Command { get; set; }
    }
}
