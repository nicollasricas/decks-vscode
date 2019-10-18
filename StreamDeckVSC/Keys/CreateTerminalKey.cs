using BarRaider.SdTools;
using StreamDeckVSC.Messages;
using StreamDeckVSC.Settings;

namespace StreamDeckVSC.Keys
{
    [PluginActionId("com.nicollasr.streamdeckvsc.createterminal")]
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
