using Newtonsoft.Json;

namespace StreamDeckVSC.Messages
{
    public class ExecuteTerminalCommandMessage
    {
        [JsonProperty("command")]
        public string Command { get; set; }

        public ExecuteTerminalCommandMessage()
        {
        }

        public ExecuteTerminalCommandMessage(string command) => Command = command;
    }
}
