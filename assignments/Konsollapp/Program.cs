using KonsollApp.Tasks;
namespace KonsollApp
{
  class Program
    {
      static string[] Tasks = {"Task1", "Task2"};
        static void Main(string[] args)
        {
          
          var isArrayEmpty = (args == null || args.Length == 0);
          string[]? arguments = isArrayEmpty ? new string[] { "" } : args;

          switch(arguments![0]) {
            case "Task1": 
              Task1.Run();
              break;
            case "Task2": 
              Task2.Run(args!);
              break;
            default:
              Console.WriteLine("No Tasks selected");
              Console.WriteLine("Select from these tasks:");
              foreach(string task in Tasks) {
                Console.WriteLine(task);
              }
              break;
          }
          
        }
    }
}

