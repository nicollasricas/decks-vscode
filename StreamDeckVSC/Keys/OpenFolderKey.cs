using BarRaider.SdTools;
using StreamDeckVSC.Messages;
using StreamDeckVSC.Settings;

namespace StreamDeckVSC.Keys
{
    [PluginActionId("com.nicollasr.streamdeckvsc.openfolder")]
    public class OpenFolderKey : KeyBase<OpenFolderSettings>
    {
        public OpenFolderKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, "Hellin:::" + settings.Path);

            MessageServer.CurrentClient?.Send(new OpenFolderMessage(settings.Path, settings.NewWindow));

            base.KeyPressed(payload);
        }
    }
}