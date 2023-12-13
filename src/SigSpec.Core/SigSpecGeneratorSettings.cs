using Newtonsoft.Json;
using NJsonSchema.Generation;

namespace SigSpec.Core
{
    public class SigSpecGeneratorSettings : JsonSchemaGeneratorSettings
    {
        public SigSpecGeneratorSettings()
        {
            SerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new UnsharedCamelCasePropertyNamesContractResolver()
            };
        }
    }
}
