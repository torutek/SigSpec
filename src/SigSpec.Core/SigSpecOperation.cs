using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SigSpec.Core
{
    public class SigSpecOperation
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("parameters")]
        public IDictionary<string, SigSpecParameter> Parameters { get; } = new Dictionary<string, SigSpecParameter>();

        [JsonPropertyName("returntype")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SigSpecReturnType ReturnType { get; set; }

        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SigSpecOperationType Type { get; set; }
    }
}