using Newtonsoft.Json;

namespace StreamDeckVSC.Settings
{
    public class ChangeLanguageSettings : KeySettings
    {
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
    }
}
