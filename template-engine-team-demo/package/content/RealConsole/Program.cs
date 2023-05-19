using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

namespace RealConsole;

internal class Program
{
    private static Task<int> Main(string[] args)
    {
        Parser parser = 
            new CommandLineBuilder(new TemplateCommand())
            .UseDefaults()
            .Build();

        return parser.Parse(args).InvokeAsync();
    }
}
