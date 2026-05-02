using CliFx;
using CliFx.Binding;
using CliFx.Infrastructure;

namespace App01;

public static class Program
{
    public static async Task<int> Main(string[] args) =>
        await new CommandLineApplicationBuilder()
            .AddCommandsFromThisAssembly()
            .Build()
            .RunAsync(args);
}

[Command("upper", Description = Constants.UpperCommandDescription)]
public sealed partial class UpperCommand : ICommand
{
    [CommandOption("input", 'i', Description = Constants.InputOptionDescription)]
    public required string Input { get; set; }

    public ValueTask ExecuteAsync(IConsole console)
    {
        Constants.Color.WriteLine($"Upper = '{Input.ToUpper()}'");
        return default;
    }
}

[Command("lower", Description = Constants.LowerCommandDescription)]
public sealed partial class LowerCommand : ICommand
{
    [CommandOption("input", 'i', Description = Constants.InputOptionDescription)]
    public required string Input { get; set; }

    public ValueTask ExecuteAsync(IConsole console)
    {
        Constants.Color.WriteLine($"Lower = '{Input.ToLower()}'");
        return default;
    }
}
