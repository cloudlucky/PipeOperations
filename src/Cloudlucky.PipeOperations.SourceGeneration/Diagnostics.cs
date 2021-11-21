using Microsoft.CodeAnalysis;

namespace Cloudlucky.PipeOperations.SourceGeneration;

public static class Diagnostics
{
    public static Diagnostic GetPipeExtensionsMaxNumberOfParametersNameMustBeAInt32()
    {
        var descriptor = new DiagnosticDescriptor("SG-0001", $"{GeneratorExecutionContextExtensions.PipeExtensionsMaxNumberOfParametersName} must be a Int32", $"The value of {GeneratorExecutionContextExtensions.PipeExtensionsMaxNumberOfParametersName} property cannot be parsed as an System.Int32. The default value will be used instead.", "Parse", DiagnosticSeverity.Warning, true);
        var diagnostic = Diagnostic.Create(descriptor, null);

        return diagnostic;
    }
    public static Diagnostic GetPipeExtensionsMaxNumberOfParametersNameMustBePositive()
    {
        var descriptor = new DiagnosticDescriptor("SG-0002", $"{GeneratorExecutionContextExtensions.PipeExtensionsMaxNumberOfParametersName} must be a positive Int32", $"The value of {GeneratorExecutionContextExtensions.PipeExtensionsMaxNumberOfParametersName} property must be a positve System.Int32.", "Parse", DiagnosticSeverity.Error, true);
        var diagnostic = Diagnostic.Create(descriptor, null);

        return diagnostic;
    }
}
