using BarRaider.SdTools;
using VSStreamDeck.Settings;

namespace VSStreamDeck.Keys
{
    [PluginActionId("com.nicollasr.vscode.createTerminal")]
    public class CodeCreateTerminalKey : KeyBase<CreateTerminalSettings>
    {
        public CodeCreateTerminalKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            MessageServer.CurrentClient?.Send(CreateRequest("vscode-create-terminal-request", keySettings));
        }
    }
}
