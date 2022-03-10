using KonsollApp.Tasks;

namespace KonsollApp;

internal static class Program
{
    private static readonly int tasks = 8;

    private static void Main(string[]? args)
    {
        var isArrayEmpty = args == null || args.Length == 0;
        var arguments = isArrayEmpty ? new[] {""} : args;

        switch (arguments![0])
        {
            case "Task1":
                Task1.Run();
                break;
            case "Task2":
                Task2.Run(args!);
                break;
            case "Task3":
                Task3.Run(args!);
                break;
            case "Task4":
                Task4.Run(args!);
                break;
            case "Task5":
                Task5.Run(args!);
                break;
            case "Task6":
                Task6.Run(args!);
                break;
            case "Task7":
                Task7.Run(args![1..]);
                break;
            case "Task8":
                Task8.Run();
                break;
            default:
                Console.WriteLine("No Tasks selected");
                Console.WriteLine("Select a task: ");
                for (var i = 1; i < tasks + 1; i++) Console.WriteLine($"Task{i}");
                break;
        }
    }
}