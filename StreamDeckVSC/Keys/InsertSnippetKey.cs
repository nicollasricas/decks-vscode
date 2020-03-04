using BarRaider.SdTools;
using StreamDeckVSC.Messages;
using StreamDeckVSC.Settings;

namespace StreamDeckVSC.Keys
{
    [PluginActionId(Program.UUID + ".insertsnippet")]
    public class InsertSnippetKey : KeyBase<InsertSnippetSettings>
    {
        public InsertSnippetKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            MessageServer.CurrentClient?.Send(new InsertSnippetMessage(settings.Name));
        }
    }
}
