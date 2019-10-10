using Newtonsoft.Json;

namespace VSStreamDeck.Messages
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
