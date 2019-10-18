using Newtonsoft.Json;

namespace StreamDeckVSC.Messages
{
    public class ExecuteCommandMessage
    {
        [JsonProperty("command")]
        public string Command { get; set; }

        //[JsonProperty("arguments")]
        //public string Arguments { get; set; }

        public ExecuteCommandMessage()
        {
        }

        public ExecuteCommandMessage(string command) => Command = command;
    }
}
