using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SigSpec.Core
{
    public class SigSpecHub
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("operations")]
        public IDictionary<string, SigSpecOperation> Operations { get; } = new Dictionary<string, SigSpecOperation>();

        [JsonPropertyName("callbacks")]
        public IDictionary<string, SigSpecOperation> Callbacks { get; } = new Dictionary<string, SigSpecOperation>();
    }
}
