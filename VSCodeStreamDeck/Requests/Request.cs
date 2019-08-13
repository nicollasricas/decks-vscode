using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace VSCodeStreamDeck.Requests
{
    public abstract class Request
    {
        [JsonProperty("id")]
        public abstract string Id { get; }

        public string SanitizeId(string id) => Regex.Replace(id, "(\\B[A-Z])", "-$1").ToLower();
    }
}
