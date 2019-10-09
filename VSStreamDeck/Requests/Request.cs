using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace VSStreamDeck.Requests
{
    public abstract class Request
    {
        [JsonProperty("id")]
        public abstract string Id { get; }

        public string SanitizeId(string id) => Regex.Replace(id, "(\\B[A-Z])", "-$1").ToLower();
    }
}
