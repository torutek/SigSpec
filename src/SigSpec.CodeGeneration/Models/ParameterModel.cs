using NJsonSchema;
using NJsonSchema.CodeGeneration;
using SigSpec.Core;

namespace SigSpec.CodeGeneration.Models
{
    public class ParameterModel
    {
        public ParameterModel(string name, SigSpecParameter parameter, TypeResolverBase resolver)
        {
            Name = name;
            Type = resolver.Resolve(parameter.ActualTypeSchema, parameter.IsNullable(SchemaType.JsonSchema), Name);
            Type = Type.Replace("?", ""); // remove any optional and we'll handle it ourselves (for now)
            Optional = parameter.Optional;
        }

        public string Name { get; }

        public string Type { get; }

        public bool Optional { get; }
    }
}
