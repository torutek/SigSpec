using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SigSpec.Core;
using Xunit;

namespace SigSpec.CodeGeneration.CSharp.Tests
{
	public class GeneratorTests
	{
		private readonly SigSpecGeneratorSettings _settings = new SigSpecGeneratorSettings();
		private readonly SigSpecGenerator _generator;

		private readonly SigSpecToCSharpGeneratorSettings _codeGeneratorSettings = new SigSpecToCSharpGeneratorSettings
		{
			CSharpGeneratorSettings =
			{
				GenerateNullableReferenceTypes = false
			}
		};

		private readonly SigSpecToCSharpGenerator _codeGenerator;

		public GeneratorTests()
		{
			_generator = new SigSpecGenerator(_settings);
			_codeGenerator = new SigSpecToCSharpGenerator(_codeGeneratorSettings);
		}

		[Theory]
		[InlineData(typeof(HubWithString), "string")]
		[InlineData(typeof(HubWithStringOptional), "string")]
		[InlineData(typeof(HubWithInt), "int")]
		[InlineData(typeof(HubWithIntOptional), "int?")]
		[InlineData(typeof(HubWithGuid), "System.Guid")]
		[InlineData(typeof(HubWithGuidOptional), "System.Guid?")]
		[InlineData(typeof(HubWithStruct), "TestStruct")]
		[InlineData(typeof(HubWithNullableStruct), "TestStruct")]
		[InlineData(typeof(HubWithStructOptional), "TestStruct")]
		[InlineData(typeof(HubWithObject), "TestClass")]
		[InlineData(typeof(HubWithObjectOptional), "TestClass")]
		[InlineData(typeof(HubWithBool), "bool")]
		[InlineData(typeof(HubWithBoolOptional), "bool?")]
		public async Task GenerateHubClient_GeneratesCorrectly(Type hub, string parameter)
		{
			var file = await GenerateHubClient(hub);
			Assert.Contains($"public Task Method({parameter} message, CancellationToken token = default(CancellationToken));", file);
		}

		[Fact]
		public async Task GenerateHubClient_IgnoresStaticMethods()
		{
			var file = await GenerateHubClient(typeof(HubWithStaticMethodTestClass));
			Assert.DoesNotContain($"public static Task Method();", file);
		}

		private async Task<string> GenerateHubClient(Type type)
		{
			var document = await _generator.GenerateForHubsAsync(new Dictionary<string, Type>
			{
				{ "Hub", type }
			});
			return _codeGenerator.GenerateClients(document);
		}
	}
}