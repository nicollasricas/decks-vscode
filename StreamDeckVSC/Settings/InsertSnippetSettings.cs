using Newtonsoft.Json;

namespace StreamDeckVSC.Settings
{
    public class InsertSnippetSettings : KeySettings
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
