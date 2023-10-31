using NJsonSchema.CodeGeneration.TypeScript;
using SigSpec.Core;
using Xunit;

namespace SigSpec.CodeGeneration.TypeScript.Tests;

public class NullableGeneratorTests
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

	public NullableGeneratorTests()
	{
		_generator = new SigSpecGenerator(_settings);
		_codeGenerator = new SigSpecToTypeScriptGenerator(_codeGeneratorSettings);
	}

	[Theory]
	[InlineData(typeof(HubWithString), "string")]
	[InlineData(typeof(HubWithStringOptional), "string | null")]
	[InlineData(typeof(HubWithInt), "number")]
	[InlineData(typeof(HubWithIntOptional), "number | null")]
	[InlineData(typeof(HubWithGuid), "string")]
	[InlineData(typeof(HubWithGuidOptional), "string | null")]
	[InlineData(typeof(HubWithStruct), "TestStruct")]
	[InlineData(typeof(HubWithNullableStruct), "TestStruct | null")]
	[InlineData(typeof(HubWithStructOptional), "TestStruct | null")]
	[InlineData(typeof(HubWithObject), "TestClass")]
	[InlineData(typeof(HubWithObjectOptional), "TestClass | null")]
	[InlineData(typeof(HubWithBool), "boolean")]
	[InlineData(typeof(HubWithBoolOptional), "boolean | null")]
	public async Task GenerateHubClient_WithNullablesAllowed_GeneratesCorrectly(Type hub, string parameter)
	{
		var file = await GenerateHubClient(hub);
		Assert.Contains($"method(message: {parameter})", file);
	}

	[Theory]
	[InlineData(typeof(HubWithReturnInt), "number")]
	[InlineData(typeof(HubWithReturnNullableInt), "number | null")]
	public async Task GenerateHubClient_WithNullablesAllowed_GeneratesReturnTypeCorrectly(Type hub, string returnType)
	{
		var file = await GenerateHubClient(hub);
		Assert.Contains($"method(): Promise<{returnType}>", file);
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