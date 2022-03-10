namespace KonsollApp.Tasks;

internal class Task2
{
    public static void Run(string[] args)
    {
        foreach (var argument in args) Console.WriteLine(argument);
    }
}