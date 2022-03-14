using Konsollapp.Exercise;
using KonsollApp.Exercise;

namespace KonsollApp;

internal static class Program
{
    // TODO: Update to use Reflection instead of switch
    private static void Main(string[]? args)
    {
        Console.WriteLine("Moodle C# Oppgaver!");
        TaskList();
        Console.Write("Velg en oppgave: ");
        int taskNum = int.Parse(Console.ReadLine()!);
        Console.Clear();
        switch (taskNum)
        {
            case 1:
                InputExercise.Run();
                break;
            case 2:
                ArgumentExercise.Run(args!);
                break;
            case 3:
                VerbatimStringExercise.Run(args!);
                break;
            case 4:
                LoopExercise.Run(args!);
                break;
            case 5:
                ReturnExercise.Run(args!);
                break;
            case 6:
                DebugExercise.Run(args!);
                break;
            case 7:
                PasswordGenerator.Run(args![1..]);
                break;
            case 8:
                LoopShapeExercises.Run();
                break;
            case 9:
                TextAnalysis.Run(args![1..]);
                break;
            case 10:
                ArrrayExercises.Run();
                break;
            default:
                Console.WriteLine("No valid task selected");
                return;
        }
    }

    private static void TaskList()
    {
        var taskNames = new[]
        {
            "Input Exercise", "Argument Exercise", "Verbatim String Exercise", "Loop Exercise", "Return Exercise", "Debug Exercise", "Password Generator",
            "Loop Shape Exercises", "Text Analysis", "Arrray Exercises"
        };
        for (int i = 0; i < taskNames.Length; i++)
        {
            Console.WriteLine($"{i+1}: {taskNames[i]}"); 
        }
    }
}