# SigSpec for SignalR Core

[![TypeScript CodeGen](https://img.shields.io/nuget/v/Torutek.SigSpec.CodeGeneration.TypeScript.svg?label=Torutek.SigSpec.CodeGeneration.Typescript)](https://www.nuget.org/packages/Torutek.SigSpec.CodeGeneration.TypeScript)
[![CSharp CodeGen](https://img.shields.io/nuget/v/Torutek.SigSpec.CodeGeneration.CSharp.svg?label=Torutek.SigSpec.CodeGeneration.CSharp)](https://www.nuget.org/packages/Torutek.SigSpec.CodeGeneration.CSharp)

Code generator for [SignalR Core](https://learn.microsoft.com/en-us/aspnet/core/signalr/introduction).

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