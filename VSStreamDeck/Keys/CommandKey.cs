using BarRaider.SdTools;
using VSCodeStreamDeck.Settings;

namespace VSCodeStreamDeck.Keys
{
    [PluginActionId("com.nicollasr.vscode.command")]
    public class CommandKey : KeyBase<CommandSettings>
    {
        public CommandKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            MessageServer.CurrentClient?.Send(CreateRequest("command-request", keySettings));
        }
    }
}