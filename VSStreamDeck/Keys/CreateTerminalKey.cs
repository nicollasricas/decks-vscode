using BarRaider.SdTools;
using VSStreamDeck.Messages;
using VSStreamDeck.Settings;

namespace VSStreamDeck.Keys
{
    [PluginActionId("com.nicollasr.vsstreamdeck.createTerminal")]
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
