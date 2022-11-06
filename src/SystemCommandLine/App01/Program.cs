using System.CommandLine;

namespace App01
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var app = new RootCommand
            {
                Name = Constants.Name, 
                Description = Constants.Description
            };

            app.AddCommand(BuildUpperCommand());
            app.AddCommand(BuildLowerCommand());
            return app.Invoke(args);
        }

        private static Command BuildUpperCommand()
        {
            var cmd = new Command(Constants.UpperCommandName, Constants.UpperCommandDescription);
            cmd.AddAlias(Constants.UpperCommandAlias);
            var inputOption = new Option<string>(new[] {"--input", "-i"}, Constants.InputOptionDescription)
            {
                IsRequired = true,
                Arity = ArgumentArity.ExactlyOne
            };
            cmd.AddOption(inputOption);
            cmd.SetHandler(context =>
            {
                var inputOptionValue = context.ParseResult.GetValueForOption(inputOption);
                if (inputOptionValue is not null)
                {
                    Constants.Color.WriteLine($"Upper = '{inputOptionValue.ToUpper()}'");
                }
                context.ExitCode = 0;
            });
            return cmd;
        }

        private static Command BuildLowerCommand()
        {
            var cmd = new Command(Constants.LowerCommandName, Constants.LowerCommandDescription);
            cmd.AddAlias(Constants.LowerCommandAlias);
            var inputOption = new Option<string>(new[] {"--input", "-i"}, Constants.InputOptionDescription)
            {
                IsRequired = true,
                Arity = ArgumentArity.ExactlyOne
            };
            cmd.AddOption(inputOption);
            cmd.SetHandler(context =>
            {
                var inputOptionValue = context.ParseResult.GetValueForOption(inputOption);
                if (inputOptionValue is not null)
                {
                    Constants.Color.WriteLine($"Lower = '{inputOptionValue.ToLower()}'");
                }
                context.ExitCode = 0;
            });
            return cmd;
        }
    }
}