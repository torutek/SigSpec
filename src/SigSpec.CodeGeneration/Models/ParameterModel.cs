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
            var containsOptional = Type.Contains("?");
            // if we are already have a ?, then we won't need to generate another one
            if (containsOptional)
            {
                GenerateOptional = false;
            }
            else
            {
                // if parameter is a value type and nullable but does not have "?" we need to add it always
                if (parameter.IsValueType && parameter.Optional)
                {
                    GenerateOptional = false;
                    Type += "?";
                }
                else
                {
                    GenerateOptional = parameter.Optional;
                }
            }
        }

        public string Name { get; }

        public string Type { get; }

        public bool GenerateOptional { get; }
    }
}
