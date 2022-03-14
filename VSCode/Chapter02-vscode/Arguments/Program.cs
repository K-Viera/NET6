using static System.Console;
// arguments in dotnet command
// dotnet run firstarg second-arg third:arg "fourth arg"
Console.Write(typeof(string).Assembly.ImageRuntimeVersion);
WriteLine($"There are {args.Length} arguments.");
foreach (string arg in args)
{
    WriteLine(arg);
}
//dotnet run red yellow 50
if (args.Length < 3)
{
    WriteLine("You must specify two colors and cursor size");
    WriteLine("dotnet run red yellow 50");
    return; // stop running
}
ForegroundColor = (ConsoleColor)Enum.Parse(
 enumType: typeof(ConsoleColor),
 value: args[0],
 ignoreCase: true);

BackgroundColor = (ConsoleColor)Enum.Parse(
 enumType: typeof(ConsoleColor),
 value: args[1],
 ignoreCase: true);

try
{
 CursorSize = int.Parse(args[2]);
}
catch (PlatformNotSupportedException)
{
 WriteLine("The current platform does not support change cursos size");
}

