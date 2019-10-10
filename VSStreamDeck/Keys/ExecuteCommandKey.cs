using BarRaider.SdTools;
using VSStreamDeck.Messages;
using VSStreamDeck.Settings;

namespace VSStreamDeck.Keys
{
    [PluginActionId("com.nicollasr.vsstreamdeck.executeCommand")]
    public class ExecuteCommandKey : KeyBase<ExecuteCommandSettings>
    {
        public ExecuteCommandKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            MessageServer.CurrentClient?.Send(new ExecuteCommandMessage(settings.Command));
        }
    }
}