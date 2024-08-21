using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using NJsonSchema;

namespace SigSpec.Core
{
    [JsonConverter(typeof(JsonReferenceResolver))]
    public class SigSpecDocument
    {
        private static readonly Lazy<JsonSerializerOptions> SerializerOptions = new(() =>
        {
            var options = new JsonSerializerOptions();
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.Converters.Add(new JsonStringEnumConverter());
            options.WriteIndented = true;
            options.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;

            return options;
        });

        /// <summary>Gets or sets the SigSpec specification version being used.</summary>
        [JsonPropertyName("sigspec")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SigSpec { get; set; } = "1.0.0";

        /// <summary>Gets or sets the metadata about the API.</summary>
        [JsonPropertyName("info")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SigSpecInfo Info { get; set; } = new SigSpecInfo();

        /// <summary>Gets the exposed SignalR hubs.</summary>
        [JsonPropertyName("hubs")]
        public IDictionary<string, SigSpecHub> Hubs { get; } = new Dictionary<string, SigSpecHub>();

        [JsonPropertyName("definitions")]
        public IDictionary<string, JsonSchema> Definitions { get; } = new Dictionary<string, JsonSchema>();

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, SerializerOptions.Value);
        }
    }
}
