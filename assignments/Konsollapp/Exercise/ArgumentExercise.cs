namespace KonsollApp.Exercise;

internal static class ArgumentExercise
{
    public static void Run(string[] args)
    {
        foreach (var argument in args) Console.WriteLine(argument);
    }
}