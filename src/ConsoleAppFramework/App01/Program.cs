using ConsoleAppFramework;

namespace App01;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var app = ConsoleApp.Create();
        app.Add<TextCommands>();
        await app.RunAsync(args);
    }
}

public sealed class TextCommands
{
    /// <summary>Convert string to uppercase</summary>
    /// <param name="input">-i, Input string.</param>
    [Command($"{Constants.UpperCommandName}|{Constants.UpperCommandAlias}")]
    public void Upper(string input)
    {
        Constants.Color.WriteLine($"Upper = '{input.ToUpper()}'");
    }

    /// <summary>Convert string to lowercase</summary>
    /// <param name="input">-i, Input string.</param>
    [Command($"{Constants.LowerCommandName}|{Constants.LowerCommandAlias}")]
    public void Lower(string input)
    {
        Constants.Color.WriteLine($"Lower = '{input.ToLower()}'");
    }
}
