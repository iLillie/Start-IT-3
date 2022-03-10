namespace KonsollApp.Tasks;

internal class Task1
{
    public static void Run()
    {
        Console.WriteLine("Hei, Hva heter du?");
        var firstName = Console.ReadLine();
        Console.WriteLine("Velkommen " + firstName);
    }
}