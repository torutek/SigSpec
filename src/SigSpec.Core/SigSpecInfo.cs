using System.Text.Json.Serialization;
using NJsonSchema;

namespace SigSpec.Core
{
    /// <summary>The web service description.</summary>
    public class SigSpecInfo : JsonExtensionObject
    {
        /// <summary>Gets or sets the title.</summary>
        [JsonPropertyName("title")]
        [JsonRequired]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Title { get; set; } = "SigSpec specification";

        /// <summary>Gets or sets the description.</summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Description { get; set; }

        /// <summary>Gets or sets the terms of service.</summary>
        [JsonPropertyName("termsOfService")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TermsOfService { get; set; }

        /// <summary>Gets or sets the API version.</summary>
        [JsonPropertyName("version")]
        [JsonRequired]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Version { get; set; } = "1.0.0";
    }
}
