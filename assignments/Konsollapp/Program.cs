using KonsollApp.Tasks;
namespace KonsollApp
{
  class Program
  {
    static int[] taskNumbers = { 1, 2, 3, 4 };
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
        default:
          Console.WriteLine("No Tasks selected");
          Console.WriteLine("Select from these tasks:");
          foreach (int taskNumber in taskNumbers)
          {
            Console.WriteLine($"Task{taskNumber}");
          }
          break;
      }

    }
  }
}

