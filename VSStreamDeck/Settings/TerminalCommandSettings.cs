using Newtonsoft.Json;

namespace VSStreamDeck.Settings
{
    public class TerminalCommandSettings : KeySettings
    {
        [JsonProperty("command")]
        public string Command { get; set; }
    }
}
