using Microsoft.CodeAnalysis;
using System;
using System.Globalization;

namespace Cloudlucky.PipeOperations.SourceGeneration;

internal static class GeneratorExecutionContextExtensions
{
    public const string PipeExtensionsMaxNumberOfParametersName = "PipeExtensionsMaxNumberOfParameters";

    public static int PipeExtensionsMaxNumberOfParameters(this GeneratorExecutionContext context, int defaultValue = default)
    {
        if (defaultValue < 0)
        {
            throw new ArgumentException("The default value must be equal or greater than 0", nameof(defaultValue));
        }

        var value = context.GetMSBuildProperty(PipeExtensionsMaxNumberOfParametersName, null);

        if (value is null)
        {
            return defaultValue;
        }

        if (int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
        {
            if (result < 0)
            {
                context.ReportDiagnostic(Diagnostics.GetPipeExtensionsMaxNumberOfParametersNameMustBePositive());
                throw new InvalidOperationException($"The {PipeExtensionsMaxNumberOfParametersName} value must be equal or greater than 0.");
            }

            return result;
        }

        context.ReportDiagnostic(Diagnostics.GetPipeExtensionsMaxNumberOfParametersNameMustBeAInt32());

        return defaultValue;
    }

    public static string GetMSBuildRootNamespace(this GeneratorExecutionContext context)
        => context.GetMSBuildProperty("RootNamespace")!;

    public static string? GetMSBuildProperty(this GeneratorExecutionContext context, string name, string? defaultValue = default)
    {
        context.AnalyzerConfigOptions.GlobalOptions.TryGetValue($"build_property.{name}", out var value);
        return value ?? defaultValue;
    }
}
