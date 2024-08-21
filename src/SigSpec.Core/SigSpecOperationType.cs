using System.Text.Json.Serialization;

namespace SigSpec.Core
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SigSpecOperationType
    {
        Sync,

        Observable
    }
}