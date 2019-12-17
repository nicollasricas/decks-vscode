using Newtonsoft.Json;

namespace StreamDeckVSC.Messages
{
    public class ChangeLanguageMessage
    {
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }

        public ChangeLanguageMessage()
        {
        }

        public ChangeLanguageMessage(string languageId) => LanguageId = languageId;
    }
}
