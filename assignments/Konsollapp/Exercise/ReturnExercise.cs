namespace KonsollApp.Exercise;

public static class ReturnExercise
{
    public static void Run(string[] args)
    {
        NoReturn();
        Console.WriteLine($"{Add(1, 2)}");
    }

    public static void NoReturn()
    {
        Console.WriteLine("Denne methoden returner ingenting");
    }

    public static int Add(int numOne, int numTwo)
    {
        return numOne + numTwo;
    }
}