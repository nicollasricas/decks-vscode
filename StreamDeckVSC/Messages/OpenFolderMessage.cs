using Newtonsoft.Json;

namespace StreamDeckVSC.Messages
{
    public class OpenFolderMessage
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("newWindow")]
        public bool NewWindow { get; set; }

        public OpenFolderMessage(string path, bool newWindow)
        {
            Path = path;
            NewWindow = newWindow;
        }
    }
}
