using BarRaider.SdTools;
using Newtonsoft.Json.Linq;
using VSStreamDeck.Settings;

namespace VSStreamDeck.Keys
{
    public abstract class KeyBase<T> : PluginBase where T : KeySettings, new()
    {
        protected PluginSettings pluginSettings;
        protected T settings;

        public KeyBase(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings is null || payload.Settings.Count == 0)
            {
                settings = new T();

                Connection.SetSettingsAsync(JObject.FromObject(settings));
            }
            else
            {
                settings = payload.Settings.ToObject<T>();
            }
        }

        public override void ReceivedGlobalSettings(ReceivedGlobalSettingsPayload payload)
        {
            if (payload.Settings?.Count > 0)
            {
                pluginSettings = payload.Settings.ToObject<PluginSettings>();
            }
        }

        public override void ReceivedSettings(ReceivedSettingsPayload payload)
        {
            if (payload.Settings?.Count > 0)
            {
                settings = payload.Settings.ToObject<T>();
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
    }
}
