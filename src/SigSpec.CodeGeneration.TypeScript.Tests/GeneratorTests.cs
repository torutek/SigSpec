using NJsonSchema.CodeGeneration.TypeScript;
using SigSpec.Core;
using Xunit;

namespace SigSpec.CodeGeneration.TypeScript.Tests
{
	public class GeneratorTests
	{
		private readonly SigSpecGeneratorSettings _settings = new SigSpecGeneratorSettings();
		private readonly SigSpecGenerator _generator;

		private readonly SigSpecToTypeScriptGeneratorSettings _codeGeneratorSettings = new()
		{
			TypeScriptGeneratorSettings =
		{
			TypeStyle = TypeScriptTypeStyle.Class,
			NullValue = TypeScriptNullValue.Null,
			MarkOptionalProperties = false,
			ConvertConstructorInterfaceData = true
		}
		};

		private readonly SigSpecToTypeScriptGenerator _codeGenerator;

		public GeneratorTests()
		{
			_generator = new SigSpecGenerator(_settings);
			_codeGenerator = new SigSpecToTypeScriptGenerator(_codeGeneratorSettings);
		}

		[Fact]
		public async Task GenerateHubClient_IgnoresStaticMethods()
		{
			var file = await GenerateHubClient(typeof(HubWithStaticMethodTestClass));
			Assert.DoesNotContain($"method(): Promise", file);
		}

		private async Task<string> GenerateHubClient(Type type)
		{
			var document = await _generator.GenerateForHubsAsync(new Dictionary<string, Type>
		{
			{ "Hub", type }
		});
			return _codeGenerator.GenerateFile(document);
		}
	}
}