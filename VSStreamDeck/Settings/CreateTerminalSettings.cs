using System.Collections.Generic;
using Newtonsoft.Json;

namespace VSCodeStreamDeck.Settings
{
    public class CreateTerminalSettings : KeySettings
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

        [JsonProperty("environment")]
        public Dictionary<string, string> Environment { get; set; }
    }
}
