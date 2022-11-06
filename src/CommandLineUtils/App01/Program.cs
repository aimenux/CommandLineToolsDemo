using McMaster.Extensions.CommandLineUtils;

namespace App01;

public static class Program
{
    public static int Main(string[] args)
    {
        var app = new CommandLineApplication
        {
            Name = Constants.Name,
            Description = Constants.Description
        };

        app.HelpOption();

        app.VersionOption("--version", "1.0.0");

        app.Command(Constants.UpperCommandName, cmd =>
        {
            cmd.AddName(Constants.UpperCommandAlias);
            cmd.Description = Constants.UpperCommandDescription;
            var inputOption = cmd.Option<string>("--input|-i", Constants.InputOptionDescription,
                CommandOptionType.SingleValue,
                configuration =>
                {
                    configuration.IsRequired();
                });
            cmd.OnExecute(() =>
            {
                if (inputOption.HasValue())
                {
                    Constants.Color.WriteLine($"Upper = '{inputOption.ParsedValue.ToUpper()}'");
                }
                return 0;
            });
        });

        app.Command(Constants.LowerCommandName, cmd =>
        {
            cmd.AddName(Constants.LowerCommandAlias);
            cmd.Description = Constants.LowerCommandDescription;
            var inputOption = cmd.Option<string>("--input|-i", Constants.InputOptionDescription, CommandOptionType.SingleValue,
                configuration =>
                {
                    configuration.IsRequired();
                });
            cmd.OnExecute(() =>
            {
                if (inputOption.HasValue())
                {
                    Constants.Color.WriteLine($"Lower = '{inputOption.ParsedValue.ToLower()}'");
                }
                return 0;
            });
        });

        return app.Execute(args);
    }
}