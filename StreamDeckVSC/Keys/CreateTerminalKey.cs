using BarRaider.SdTools;
using StreamDeckVSC.Messages;
using StreamDeckVSC.Settings;

namespace StreamDeckVSC.Keys
{
    [PluginActionId(Program.UUID + ".createterminal")]
    public class CreateTerminalKey : KeyBase<CreateTerminalSettings>
    {
        public CreateTerminalKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            MessageServer.CurrentClient?.Send(new CreateTerminalMessage()
            {
                Name = settings.Name,
                PreserveFocus = settings.PreserveFocus,
                ShellArgs = settings.ShellArgs,
                ShellPath = settings.ShellPath,
                WorkingDirectory = settings.WorkingDirectory
            });
        }
    }
}
