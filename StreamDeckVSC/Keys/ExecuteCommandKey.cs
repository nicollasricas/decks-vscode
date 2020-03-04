using BarRaider.SdTools;
using StreamDeckVSC.Messages;
using StreamDeckVSC.Settings;

namespace StreamDeckVSC.Keys
{
    [PluginActionId(Program.UUID + ".executecommand")]
    public class ExecuteCommandKey : KeyBase<ExecuteCommandSettings>
    {
        public ExecuteCommandKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            MessageServer.CurrentClient?.Send(new ExecuteCommandMessage()
            {
                Command = settings.Command,
                Arguments = settings.Arguments
            });
        }
    }
}