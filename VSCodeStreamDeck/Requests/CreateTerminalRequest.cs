using Newtonsoft.Json;

namespace VSCodeStreamDeck.Requests
{
    class CreateTerminalRequest : Request
    {
        public override string Id => SanitizeId(nameof(CreateTerminalRequest));

        [JsonProperty("preserveFocus")]
        public bool PreserveFocus { get; set; }

        public CreateTerminalRequest()
        {
        }

        public CreateTerminalRequest(bool preserveFocus) => PreserveFocus = preserveFocus;
    }
}
