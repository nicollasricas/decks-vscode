using Newtonsoft.Json;

namespace StreamDeckVSC.Messages
{
    public class InsertSnippetMessage
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        public InsertSnippetMessage()
        {
        }

        public InsertSnippetMessage(string name) => Name = name;
    }
}
