using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VSCodeStreamDeck.Settings;

namespace VSCodeStreamDeck.Keys
{
    public abstract class KeyBase<T> : PluginBase where T : KeySettings, new()
    {
        protected PluginSettings settings;
        protected T keySettings;

        public KeyBase(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings is null || payload.Settings.Count == 0)
            {
                keySettings = new T();

                Connection.SetSettingsAsync(JObject.FromObject(keySettings));
            }
            else
            {
                keySettings = payload.Settings.ToObject<T>();
            }
        }

        public override void ReceivedGlobalSettings(ReceivedGlobalSettingsPayload payload)
        {
            if (payload.Settings?.Count > 0)
            {
                settings = payload.Settings.ToObject<PluginSettings>();
            }
        }

        public override void ReceivedSettings(ReceivedSettingsPayload payload)
        {
            if (payload.Settings?.Count > 0)
            {
                keySettings = payload.Settings.ToObject<T>();
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

        public void Ok() => Connection.ShowOk();

        public void Fail() => Connection.ShowAlert();

        protected string CreateRequest(string id, object payload)
        {
            var request = JObject.FromObject(payload);
            request.Add("id", id);

            return request.ToString(Formatting.None);
        }
    }
}
