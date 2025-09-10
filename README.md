# SigSpec for SignalR Core

TODO Update these:
[![Azure DevOps](https://img.shields.io/azure-devops/build/rsuter/Namotion/22/master.svg)](https://dev.azure.com/rsuter/Namotion/_build?definitionId=22)
[![Azure DevOps](https://img.shields.io/azure-devops/coverage/rsuter/Namotion/22/master.svg)](https://dev.azure.com/rsuter/Namotion/_build?definitionId=22)
[![Nuget](https://img.shields.io/nuget/v/SigSpec.Core.svg)](https://www.nuget.org/packages?q=sigspec)

**Experimental API endpoint specification** and code generator for [SignalR Core](https://github.com/aspnet/SignalR).

Based on [NJsonSchema](http://njsonschema.org) (see also: [NSwag](http://nswag.org)).

# Usage

## Generate CSharp Client

```csharp
var sigSpecSettings = new SigSpecGeneratorSettings();
var generator = new SigSpecGenerator(sigSpecSettings);

var document = await generator.GenerateForHubsAsync(new Dictionary<string, Type>
  {
    { "my-hub", typeof(MyHub) }
  });

var codeGeneratorSettings = new SigSpecToCSharpGeneratorSettings
{
  CSharpGeneratorSettings =
  {
    Namespace = "MyProject.SignalR.Clients",
    GenerateNullableReferenceTypes = true,
  }
};

var codeGenerator = new SigSpecToCSharpGenerator(codeGeneratorSettings);
var code = codeGenerator.GenerateClients(document);
File.WriteAllText("SignalRClient.cs", code);
```

## Generate TypeScript Client

```csharp
var sigSpecSettings = new SigSpecGeneratorSettings();
var generator = new SigSpecGenerator(sigSpecSettings);

var document = await generator.GenerateForHubsAsync(new Dictionary<string, Type>
{
  { "my-hub", typeof(MyHub) }
});

var codeGeneratorSettings = new SigSpecToTypeScriptGeneratorSettings
{
  TypeScriptGeneratorSettings =
  {
    TypeStyle = TypeScriptTypeStyle.Class,
    NullValue = TypeScriptNullValue.Null,
    MarkOptionalProperties = false,
    ConvertConstructorInterfaceData = true
  }
};

var codeGenerator = new SigSpecToTypeScriptGenerator(codeGeneratorSettings);
var code = string.Join(Environment.NewLine,
  "/* tslint:disable */",
  "/* eslint-disable */",
  "// @ts-ignore",
  codeGenerator.GenerateFile(document)
);
File.WriteAllText("SignalRClient.ts", code);
```