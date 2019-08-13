using System.Threading.Tasks;
using BarRaider.SdTools;
using Newtonsoft.Json.Linq;
using VSCodeStreamDeck.Settings;

namespace VSCodeStreamDeck.Keys
{
    public abstract class KeyBase<T> : PluginBase where T : KeySettings, new()
    {
        protected PluginSettings settings;
        protected T keySettings;

        private readonly SDConnection connection;
        private readonly string keyName;

        public KeyBase(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            this.connection = connection;

            keyName = GetType().Name;

            if (payload.Settings is null || payload.Settings.Count == 0)
            {
                Logger.Instance.LogMessage(TracingLevel.WARN, $"No settings found for {keyName}, default applied...");

                keySettings = new T();

                Tools.AutoPopulateSettings(keySettings, JObject.FromObject(keySettings));
            }
        }

        public override void ReceivedGlobalSettings(ReceivedGlobalSettingsPayload payload)
        {
            if (payload.Settings?.Count > 0)
            {
                Logger.Instance.LogMessage(TracingLevel.INFO, $"Received global settings into {keyName}.");

                Tools.AutoPopulateSettings(settings, payload.Settings);
            }
        }

        public override void ReceivedSettings(ReceivedSettingsPayload payload)
        {
            if (payload.Settings?.Count > 0)
            {
                Logger.Instance.LogMessage(TracingLevel.INFO, $"Received {keyName} settings." + payload.Settings.ToString());

                Tools.AutoPopulateSettings(keySettings, payload.Settings);
            }
        }

        public override void Dispose()
        {
        }

        public override void KeyReleased(KeyPayload payload)
        {
        }

        public override void OnTick()
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
        }

        public void Ok() => connection.ShowOk();

        public void Fail() => connection.ShowAlert();

        public void HandleResponse(string response)
        {
            if (string.IsNullOrEmpty(response) && settings.Feedback)
            {
                // do something
            }
        }
    }
}
