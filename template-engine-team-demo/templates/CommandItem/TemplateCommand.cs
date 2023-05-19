using System.CommandLine;
using System.CommandLine.Invocation;

namespace DefaultNamespace;

internal class TemplateCommand : Command, ICommandHandler
{
    internal Option<string> SampleOption { get; } = new Option<string>("--sample", () => "World", "this is a sample option.");

    internal TemplateCommand() : base("template-command")
    {
        AddOption(SampleOption);
        Handler = this;
    }

    public int Invoke(InvocationContext context)
    {
        string? sampleOptionValue = context.ParseResult.GetValueForOption(SampleOption) ?? "World";
        Console.WriteLine($"Hello, {sampleOptionValue}!");
        return 0;
    }

    public Task<int> InvokeAsync(InvocationContext context) => Task.FromResult(Invoke(context));
}
