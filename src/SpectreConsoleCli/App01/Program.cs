using Spectre.Console.Cli;
using System.ComponentModel;

namespace App01;

public static class Program
{
    public static int Main(string[] args)
    {
        var app = new CommandApp();

        app.Configure(config =>
        {
            config.AddCommand<UpperCommand>(Constants.UpperCommandName)
                .WithAlias(Constants.UpperCommandAlias)
                .WithDescription(Constants.UpperCommandDescription);

            config.AddCommand<LowerCommand>(Constants.LowerCommandName)
                .WithAlias(Constants.LowerCommandAlias)
                .WithDescription(Constants.LowerCommandDescription);
        });

        return app.Run(args);
    }

    private class UpperCommand : Command<InputSetting>
    {
        public override int Execute(CommandContext context, InputSetting settings, CancellationToken cancellationToken)
        {
            Constants.Color.WriteLine($"Upper = '{settings.Input.ToUpper()}'");
            return 0;
        }
    }

    private sealed class LowerCommand : Command<InputSetting>
    {
        public override int Execute(CommandContext context, InputSetting settings, CancellationToken cancellationToken)
        {
            Constants.Color.WriteLine($"Lower = '{settings.Input.ToLower()}'");
            return 0;
        }
    }

    private sealed class InputSetting : CommandSettings
    {
        [Description(Constants.InputOptionDescription)]
        [CommandOption("-i|--input <INPUT>")]
        public string Input { get; init; }
    }
}