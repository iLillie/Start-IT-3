namespace KonsollApp.Tasks;

public class Task7
{
    // Password Generator
    // Args:
    // 0: Amount of characters a password need
    // 1: Pattern 
    // l: lower case letter
    // L: upper case letter
    // d: digit
    // s: special character (!"#¤%&/(){}[]
    private const char MinUpperCaseLetter = 'A';
    private const char MaxUpperCaseLetter = 'Z';
    private const char MinLowerCaseLetter = 'a';
    private const char MaxLowerCaseLetter = 'z';
    private const char MinDigitLetter = '0';
    private const char MaxDigitLetter = '9';
    private const char MinSpecialDigit = '!';
    private const char MaxSpecialDigit = ')';
    private const string allowedPatterns = "lLds";
    private static readonly Random rand = new();


    public static void Run(string[] args)
    {
        var hasNotEnoughArguments = args.Length < 2;

        if (hasNotEnoughArguments)
        {
            WriteLineInfo();
            return;
        }

        var hasInvalidArguments = !HasValidArguments(args);

        if (hasInvalidArguments)
        {
            WriteLineInfo();
            return;
        }

        var passwordLength = ParseLength(args[0]);
        var passwordPattern = args[1];

        var password = GeneratePassword(passwordPattern, passwordLength);

        Console.WriteLine(password);
    }

    private static string GeneratePassword(string passwordPattern, int passwordLength)
    {
        var passwordString = new string('l', passwordLength);
        foreach (var letter in passwordString)
        {
        }

        return passwordString;
    }

    private static void WriteLineInfo()
    {
        var infoText = @"
      PasswordGenerator  
        Options:
        - l = lower case letter
        - L = upper case letter
        - d = digit
        - s = special character (!""#¤%&/(){}[]
        Example: PasswordGenerator 14 lLssdd
          Min. 1 lower case
          Min. 1 upper case
          Min. 2 special characters
          Min. 2 digits";
        Console.WriteLine(infoText);
    }

    private static char RandomLetter(char minLetter, char maxLetter)
    {
        var randomLetter = (char) rand.Next(minLetter, maxLetter + 1);
        return randomLetter;
    }

    private static bool HasValidArguments(string[] args)
    {
        var isLengthInvalidNumber = !IsValidNumber(args[0]);
        if (isLengthInvalidNumber)
        {
            WriteLineError("Password length is not a number");
            return false;
        }

        var isPatternInvalid = !IsValidPattern(args[1]);
        if (isPatternInvalid)
        {
            WriteLineError("Password pattern is not valid.");
            return false;
        }

        return true;
    }

    private static void WriteLineError(string errorText)
    {
        Console.WriteLine("Error:");
        Console.WriteLine(errorText);
    }

    private static bool IsValidNumber(string value)
    {
        return int.TryParse(value, out var n);
    }

    private static bool IsValidPattern(string pattern)
    {
        foreach (var character in pattern)
        {
            var validCharacter = allowedPatterns.Contains(character);

            if (validCharacter) continue;

            return false;
        }

        return true;
    }

    private static int ParseLength(string str)
    {
        return int.Parse(str);
    }
}