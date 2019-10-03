using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VSCodeStreamDeck.Requests;
using VSCodeStreamDeck.Settings;

namespace VSCodeStreamDeck.Keys
{
    [PluginActionId("com.nicollasr.vscode.terminalCommand")]
    public class TerminalCommandKey : KeyBase<TerminalCommandSettings>
    {
        public TerminalCommandKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            MessageServer.CurrentClient?.Send(CreateRequest("terminal-command-request", keySettings));
        }
    }
}
