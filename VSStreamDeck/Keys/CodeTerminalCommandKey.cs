using BarRaider.SdTools;
using VSStreamDeck.Settings;

namespace VSStreamDeck.Keys
{
    [PluginActionId("com.nicollasr.vscode.terminalCommand")]
    public class CodeTerminalCommandKey : KeyBase<TerminalCommandSettings>
    {
        public CodeTerminalCommandKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            MessageServer.CurrentClient?.Send(CreateRequest("terminal-command-request", keySettings));
        }
    }
}
