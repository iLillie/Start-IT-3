namespace KonsollApp.Tasks;

internal class Task4
{
    public static void Run(string[] args)
    {
        for (var i = 0; i < 5; i++) Console.WriteLine("Terje er kul :D");
        foreach (var wordChar in "Welcome") Console.WriteLine(wordChar);
    }
}