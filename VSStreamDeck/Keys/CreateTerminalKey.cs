using BarRaider.SdTools;
using Newtonsoft.Json;
using VSCodeStreamDeck.Requests;
using VSCodeStreamDeck.Settings;

namespace VSCodeStreamDeck.Keys
{
    [PluginActionId("com.nicollasr.vscode.createTerminal")]
    public class CreateTerminalKey : KeyBase<CreateTerminalSettings>
    {
        public CreateTerminalKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            MessageServer.CurrentClient?.Send(CreateRequest("create-terminal-request", keySettings));
        }
    }
}
