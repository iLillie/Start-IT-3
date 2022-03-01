namespace KonsollApp.Tasks
{
  class Task4
  {
    public static void Run(string[] args)
    {
      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine("Terje er kul :D");
      }
      foreach (char wordChar in "Welcome")
      {
        Console.WriteLine(wordChar);
      }
    }
  }
}