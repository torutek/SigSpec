using System.Text.Json;
using NJsonSchema.Generation;

namespace SigSpec.Core
{
    public class SigSpecGeneratorSettings : SystemTextJsonSchemaGeneratorSettings
    {
        public SigSpecGeneratorSettings()
        {
            SerializerOptions = new(JsonSerializerDefaults.Web);
        }
    }
}
