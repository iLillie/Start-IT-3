namespace KonsollApp.Tasks
{
  class Task2
  {
    public static void Run(string[] args)
    {
        foreach (string argument in args)
        {
          Console.WriteLine(argument);
        }
    }
  }
}