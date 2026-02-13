using System.CommandLine;

namespace App01;

public static class Program
{
    public static int Main(string[] args)
    {
        var app = new RootCommand(Constants.Description)
        {
            BuildUpperCommand(),
            BuildLowerCommand()
        };

        return app.Parse(args).Invoke();
    }

    private static Command BuildUpperCommand()
    {
        var inputOption = new Option<string>("input", "i")
        {
            Required = true,
            Arity = ArgumentArity.ExactlyOne,
            Description = Constants.InputOptionDescription,
        };
        
        var cmd = new Command(Constants.UpperCommandName, Constants.UpperCommandDescription)
        {
            Aliases = { Constants.UpperCommandAlias },
            Options = { inputOption }
        };
        
        cmd.SetAction(parseResult =>
        {
            var inputOptionValue = parseResult.GetValue(inputOption);
            if (inputOptionValue is not null)
            {
                Constants.Color.WriteLine($"Upper = '{inputOptionValue.ToUpper()}'");
            } 
            return 0;
        });
        
        return cmd;
    }

    private static Command BuildLowerCommand()
    {
        var inputOption = new Option<string>("input", "i")
        {
            Required = true,
            Arity = ArgumentArity.ExactlyOne,
            Description = Constants.InputOptionDescription,
        };
        
        var cmd = new Command(Constants.LowerCommandName, Constants.LowerCommandDescription)
        {
            Aliases = { Constants.LowerCommandAlias },
            Options = { inputOption }
        };
        
        cmd.SetAction(parseResult =>
        {
            var inputOptionValue = parseResult.GetValue(inputOption);
            if (inputOptionValue is not null)
            {
                Constants.Color.WriteLine($"Lower = '{inputOptionValue.ToLower()}'");
            } 
            return 0;
        });
        
        return cmd;
    }
}