using BarRaider.SdTools;
using Newtonsoft.Json;
using VSStreamDeck.Settings;

namespace VSStreamDeck.Keys
{
    public class CommandSettings : KeySettings
    {
        [JsonProperty("command")]
        public string Command { get; set; }

        [JsonProperty("arguments")]
        public string Arguments { get; set; }
    }

    [PluginActionId("com.nicollasr.vscode.command")]
    public class CodeCommandKey : KeyBase<CommandSettings>
    {
        public CodeCommandKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            MessageServer.CurrentClient?.Send(CreateRequest("vscode-command-request", keySettings));
        }
    }
}