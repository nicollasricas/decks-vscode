using Newtonsoft.Json;

namespace StreamDeckVSC.Settings
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
    }
}
