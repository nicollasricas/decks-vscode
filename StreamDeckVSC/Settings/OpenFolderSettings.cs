using Newtonsoft.Json;

namespace StreamDeckVSC.Settings
{
    public class OpenFolderSettings : KeySettings
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("newWindow")]
        public bool NewWindow { get; set; }
    }
}
