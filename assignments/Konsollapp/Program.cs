using KonsollApp.Tasks;
namespace KonsollApp
{
  class Program
  {
    static int tasks = 6;
    static void Main(string[] args)
    {

      var isArrayEmpty = (args == null || args.Length == 0);
      string[]? arguments = isArrayEmpty ? new string[] { "" } : args;

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
        default:
          Console.WriteLine("No Tasks selected");
          Console.WriteLine("Select from these tasks:");
          for (int i = 1; i < tasks + 1; i++)
          {
            Console.WriteLine($"Task{i}");
          }
          break;
      }

    }
  }
}

