namespace App01;

public static class Constants
{
    public const string Name = "CommandLineToolsDemo";
    public const string Description = "Command line tools frameworks";

    public const string UpperCommandName = "upper";
    public const string UpperCommandAlias = "uppercase";
    public const string LowerCommandName = "lower";
    public const string LowerCommandAlias = "lowercase";

    public const string UpperCommandDescription = "Convert string to uppercase";
    public const string LowerCommandDescription = "Convert string to lowercase";

    public const string InputOptionDescription = "Input string";

    public const ConsoleColor Color = ConsoleColor.Yellow;

    public static void WriteLine(this ConsoleColor color, object value)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(value);
        Console.ResetColor();
    }
}