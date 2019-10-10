using BarRaider.SdTools;
using VSStreamDeck.Messages;
using VSStreamDeck.Settings;

namespace VSStreamDeck.Keys
{
    [PluginActionId("com.nicollasr.vsstreamdeck.executeTerminalCommand")]
    public class ExecuteTerminalCommandKey : KeyBase<TerminalCommandSettings>
    {
        public ExecuteTerminalCommandKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            MessageServer.CurrentClient?.Send(new ExecuteTerminalCommandMessage(settings.Command));
        }
    }
}
