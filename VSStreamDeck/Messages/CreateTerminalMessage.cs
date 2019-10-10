using Newtonsoft.Json;

namespace VSStreamDeck.Messages
{
    public class CreateTerminalMessage
    {
        [JsonProperty("preserveFocus")]
        public bool PreserveFocus { get; set; } = false;

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shellPath")]
        public string ShellPath { get; set; }

        [JsonProperty("shellArgs")]
        public string ShellArgs { get; set; }

        [JsonProperty("workingDirectory")]
        public string WorkingDirectory { get; set; }
    }
}
