using NJsonSchema;
using NJsonSchema.CodeGeneration;
using SigSpec.Core;

namespace SigSpec.CodeGeneration.Models
{
    public class ReturnTypeModel
    {
        private readonly JsonSchema _parameter;
        private readonly TypeResolverBase _resolver;

        public ReturnTypeModel(SigSpecReturnType parameter, TypeResolverBase resolver)
        {
            _parameter = parameter;
            _resolver = resolver;

            Type = _resolver.Resolve(_parameter.ActualTypeSchema, _parameter.IsNullable(SchemaType.JsonSchema), null);
            var containsOptional = Type.Contains('?');
            Nullable = parameter.Nullable && !containsOptional;
        }

        public string Type { get; }

        public bool Nullable { get; }
    }
}