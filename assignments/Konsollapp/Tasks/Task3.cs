namespace KonsollApp.Tasks;

internal class Task3
{
    public static void Run(string[] args)
    {
        var firstNumber = 5.0f;
        var secondNumber = 3.0f;
        Console.WriteLine(
            $"Input: første Nummer: {firstNumber} andre Nummer: {secondNumber} og summen av disse er: {firstNumber + secondNumber}");
    }
}