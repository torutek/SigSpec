using System.Reflection;
using NJsonSchema.CodeGeneration.CSharp;

namespace SigSpec.CodeGeneration.CSharp
{
    public class SigSpecToCSharpGeneratorSettings : SigSpecToCSharpGeneratorSettingsBase
    {
        public SigSpecToCSharpGeneratorSettings()
            : base(new CSharpGeneratorSettings())
        {
            CodeGeneratorSettings.TemplateFactory = new DefaultTemplateFactory(CSharpGeneratorSettings, new[]
            {
                typeof(CSharpGeneratorSettings).GetTypeInfo().Assembly,
                typeof(SigSpecToCSharpGeneratorSettingsBase).GetTypeInfo().Assembly
            });
        }

        public CSharpGeneratorSettings CSharpGeneratorSettings => (CSharpGeneratorSettings)CodeGeneratorSettings;

        /// <summary>
        /// Whether to add #nullable enable to the top the hub file
        /// </summary>
        public bool EnableNullable { get; set; }
    }
}
