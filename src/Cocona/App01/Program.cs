using Cocona;

namespace App01;

public static class Program
{
    public static int Main(string[] args)
    {
        var app = CoconaApp.Create(args);

        app
            .AddCommand(Constants.UpperCommandName,
                ([Option("input", new[] {'i'}, Description = Constants.InputOptionDescription)] string input) =>
                {
                    if (input is not null)
                    {
                        Constants.Color.WriteLine($"Upper = '{input.ToUpper()}'");
                    }
                })
            .WithDescription(Constants.UpperCommandDescription)
            .WithAliases(Constants.UpperCommandAlias);

        app
            .AddCommand(Constants.LowerCommandName,
                ([Option("input", new[] {'i'}, Description = Constants.InputOptionDescription)] string input) =>
                {
                    if (input is not null)
                    {
                        Constants.Color.WriteLine($"Lower = '{input.ToLower()}'");
                    }
                })
            .WithDescription(Constants.LowerCommandDescription)
            .WithAliases(Constants.LowerCommandAlias);

        app.Run();
        return 0;
    }
}