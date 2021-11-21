using Microsoft.CodeAnalysis;
using Scriban;

namespace Cloudlucky.PipeOperations.SourceGeneration;

[Generator]
public class SourceGenerator : ISourceGenerator
{
    private const int PipeExtensionsMaxNumberOfParameters = 8;

    public void Initialize(GeneratorInitializationContext context)
    {
        // No initialization required for this one
    }

    public void Execute(GeneratorExecutionContext context)
    {
        AddPipeExtensionsSource(context, "PipeAsyncExtensions");
        AddPipeExtensionsSource(context, "PipeExtensions");
    }

    private static void AddPipeExtensionsSource(GeneratorExecutionContext context, string name)
    {
        var rootNamespace = context.GetMSBuildRootNamespace();
        var language = context.Compilation.Language.Replace("#", "sharp").ToLowerInvariant();

        var templateString = ResourceReader.GetResource($"{name}.{language}.scriban");
        var template = Template.Parse(templateString);
        var result = template.Render(new { RootNamespace = rootNamespace, Times = context.PipeExtensionsMaxNumberOfParameters(PipeExtensionsMaxNumberOfParameters) });

        context.AddSource(name, result);
    }
}
