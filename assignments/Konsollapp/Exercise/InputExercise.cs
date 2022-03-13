namespace KonsollApp.Exercise;

internal static class InputExercise
{
    public static void Run()
    {
        Console.WriteLine("Hei, Hva heter du?");
        var firstName = Console.ReadLine();
        Console.WriteLine("Velkommen " + firstName);
    }
}