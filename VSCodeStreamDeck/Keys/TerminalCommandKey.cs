using BarRaider.SdTools;
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
        }
    }
}
