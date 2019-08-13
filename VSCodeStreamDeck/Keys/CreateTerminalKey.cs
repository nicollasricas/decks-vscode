using BarRaider.SdTools;
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
            VSServer.Current?.Send(new CreateTerminalRequest(keySettings.PreserveFocus));
        }
    }
}
