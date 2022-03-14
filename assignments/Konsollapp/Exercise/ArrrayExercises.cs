using System.Text;

namespace KonsollApp.Exercise;

public static class ArrrayExercises
{
    private static readonly char[] cipherArray = new char[26] {'Z', 'Y', 'X', 'W', 'V', 'U', 
        'T', 'S', 'R', 'Q', 'P', 'O', 'N', 'M', 'L', 'K', 'J',
        'I', 'H', 'G', 'F', 'E', 'D', 'C', 'B', 'A'};

    public static void Run()
    {
        Console.WriteLine(IsArraySorted(new int[] {1, 2, 3, 4}, 4));
        var chiperText = CipherText("HELLO WORLD!");
        Console.WriteLine(chiperText);
        Console.WriteLine(DecipherText(chiperText));
    }

    private static bool IsArraySorted(IReadOnlyList<int> numArray, int elementCount)
    {
        var lastValue = 0;
        for (var i = 0; i < elementCount; i++)
        {
            if (lastValue >= numArray[i]) return false;
            lastValue = numArray[i];
        }

        return true;
    }

    private static string CipherText(string input)
    {
        var sb = new StringBuilder(input);
        for (var i = 0; i < input.Length; i++)
        {
            var characterCode = (int)input[i];
            var notUpperCaseCharCode = characterCode is not (< 91 and > 64);
            if (notUpperCaseCharCode) continue;
            sb[i] = cipherArray[characterCode - 65];
        }

        return sb.ToString();
    }

    private static string DecipherText(string cipherText)
    {
        var sb = new StringBuilder(cipherText);
        for (var i = 0; i < cipherText.Length; i++)
        {
            var characterCode = (int)cipherText[i];
            var notUpperCaseCharCode = characterCode is not (< 91 and > 64);
            if (notUpperCaseCharCode) continue;
            for (var j = 0; j < cipherArray.Length; j++)
            {
                if (cipherArray[j] == cipherText[i])
                {
                    sb[i] = (char)(j + 65);
                }
            }
        }
        return sb.ToString();
    }
}