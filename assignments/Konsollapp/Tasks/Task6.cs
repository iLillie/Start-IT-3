namespace KonsollApp.Tasks
{
  public class Task6
  {
    public static void Run(string[] args)
    {
      var range = 250;
      var counts = new int[range];
      string? text = "something";
      int totalLetters = 0;
      while (!string.IsNullOrWhiteSpace(text))
      {
        text = Console.ReadLine();
        foreach (var character in text!.ToUpper() ?? string.Empty)
        {
          totalLetters++;
          counts[(int)character]++;
        }
        for (var i = 0; i < range; i++)
        {
          if (counts[i] > 0)
          {
            var character = (char)i;
            var percentage = 100 * (float)counts[i] / totalLetters;
            string output = character + " - " + percentage.ToString("F2") + "%";
            Console.CursorLeft = Console.BufferWidth - output.Length - 1;
            Console.WriteLine(output);
          }
        }
      }
    }
  }
}