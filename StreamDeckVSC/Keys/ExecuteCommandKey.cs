using BarRaider.SdTools;
using StreamDeckVSC.Messages;
using StreamDeckVSC.Settings;

namespace StreamDeckVSC.Keys
{
    [PluginActionId("com.nicollasr.streamdeckvsc.executecommand")]
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