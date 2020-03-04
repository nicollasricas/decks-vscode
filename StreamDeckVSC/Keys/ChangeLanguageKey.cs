using BarRaider.SdTools;
using StreamDeckVSC.Messages;
using StreamDeckVSC.Settings;

namespace StreamDeckVSC.Keys
{
    [PluginActionId(Program.UUID + ".changelanguage")]
    public class ChangeLanguageKey : KeyBase<ChangeLanguageSettings>
    {
        public ChangeLanguageKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            MessageServer.CurrentClient?.Send(new ChangeLanguageMessage(settings.LanguageId));
        }
    }
}
