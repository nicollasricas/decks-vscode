using BarRaider.SdTools;
using StreamDeckVSC.Messages;
using StreamDeckVSC.Settings;

namespace StreamDeckVSC.Keys
{
    [PluginActionId(Program.UUID + ".executeterminalcommand")]
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
