using System.Text;
namespace KonsollApp.Tasks
{
  public class Task7
  {
    // Password Generator
    // Args:
    // 0: Amount of characters a password need
    // 1: Options 
    // l: lower case letter
    // L: upper case letter
    // d: digit
    // s: special character (!"#¤%&/(){}[]
    const char MinUpperCaseLetter = 'A';
    const char MaxUpperCaseLetter = 'Z';
    const char MinLowerCaseLetter = 'a';
    const char MaxLowerCaseLetter = 'z';
    const char MinDigitLetter = '0';
    const char MaxDigitLetter = '9';

    const char MinSpecialDigit = '!';
    const char MaxSpecialDigit = ')';
    static readonly Random rand = new Random();


    public static void Run(string[] args)
    {
      Console.WriteLine($"{args[1]}");
      bool hasInvalidArguments = !ValidateArguments(args);
      if (hasInvalidArguments) return;
      int passwordLength = Int32.Parse(args[0]);
      string passwordOptions = args[1];
      int[] parsedOptions = ParseOptions(passwordOptions, passwordLength);
      Console.WriteLine(GeneratePassword(parsedOptions, passwordLength));
    }

    private static string GeneratePassword(int[] parsedOptions, int passwordLength)
    {
      var generatedPassword = new StringBuilder(passwordLength);
      int[] parsedOptionsCopy = (int[])parsedOptions.Clone();
      while (generatedPassword.Length != passwordLength)
      {
        int optionToSelect = rand.Next(0, 4);
        bool isOptionEmpty = parsedOptionsCopy[optionToSelect] == 0;
        if(isOptionEmpty) continue;
        switch(optionToSelect) {
          case 0: 
            AppendRandomLetterSB(generatedPassword, MinLowerCaseLetter, MaxLowerCaseLetter);
            parsedOptionsCopy[0] -= 1;
          break;
          case 1: 
             AppendRandomLetterSB(generatedPassword, MinUpperCaseLetter, MaxUpperCaseLetter);
             parsedOptionsCopy[1] -= 1;
          break;
          case 2:
            AppendRandomLetterSB(generatedPassword, MinDigitLetter, MaxDigitLetter);
            parsedOptionsCopy[2] -= 1;
          break;
          case 3:
            AppendRandomLetterSB(generatedPassword, MinSpecialDigit, MaxSpecialDigit);
            parsedOptionsCopy[3] -= 1;
          break;
        }
      }
      return generatedPassword.ToString();
    }

    private static void AppendRandomLetterSB(StringBuilder input, char minLetter, char maxLetter) {
      input.Append(RandomLetter(minLetter, maxLetter));
    }

    private static int[] ParseOptions(string passwordOptions, int passwordLength)
    {
      int[] parsedOptions = new int[4];
      foreach (char optionLetter in passwordOptions)
      {
        switch (optionLetter)
        {
          case 'l':
            parsedOptions[0] += 1;
            break;
          case 'L':
            parsedOptions[1] += 1;
            break;
          case 'd':
            parsedOptions[2] += 1;
            break;
          case 's':
            parsedOptions[3] += 1;
            break;
        }
      }
      int restLowerCaseLength = passwordLength - passwordOptions.Length;
      parsedOptions[0] += restLowerCaseLength;
      return parsedOptions;
    }

    private static char RandomLetter(char minLetter, char maxLetter)
    {
      char randomLetter = (char)(rand.Next(minLetter, maxLetter+1));
      return randomLetter;
    }

    private static bool ValidateArguments(string[] args)
    {
      string passwordLength = args[0];
      bool isInvalidPasswordLength = !ValidateLength(passwordLength);
      if (isInvalidPasswordLength)
      {
        WriteHelpText("Password length not valid");
        return false;
      }

      string passwordOptions = args[1];
      bool isInvalidPasswordOptions = !ValidateOptions(passwordOptions);
      if (isInvalidPasswordOptions)
      {
        WriteHelpText("Password options not valid");
        return false;
      }

      return true;
    }

    private static void WriteHelpText(string errorText)
    {
      Console.WriteLine("Validation failed:");
      Console.WriteLine(errorText);
      Console.WriteLine("Try again");
    }

    private static bool ValidateLength(string value)
    {
      int _ = 0;
      bool argumentOneIsInt = Int32.TryParse(value, out _);
      if (!argumentOneIsInt) return false;
      return true;
    }

    private static bool ValidateOptions(string value)
    {
      foreach (char character in value)
      {
        switch (character)
        {
          case 'l':
          case 'L':
          case 'd':
          case 's':
            break;
          default:
            return false;
        }
      }
      return true;
    }
  }
}