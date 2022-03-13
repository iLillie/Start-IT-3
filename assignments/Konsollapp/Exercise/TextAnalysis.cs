namespace KonsollApp.Exercise;

public static class TextAnalysis
{
    private static string[] _vowels = new[] {"a", "e", "i", "o", "u"}; 
    public static void Run(string[] args)
    {
        string lineOfText = args[0];
        int wordCount = GetWordCount(lineOfText);
        int longestWordLength = LongestWordLength(lineOfText);
        int greatestVowelCount = GreatestVowelInAWordCount(lineOfText);
        Console.WriteLine($"There are {wordCount}, longest word has {longestWordLength} characters,");
        Console.WriteLine($"and longest vowel count is {greatestVowelCount}.");
    }

    private static int GetWordCount(string text)
    {
        int wordCount = text.Split(" ").Length;
        return wordCount;
    }

    private static int LongestWordLength(string text)
    {
        string[] words = text.Split(" ");
        int longestWord = 0;
        foreach (var word in words)
        {
            longestWord = word.Length > longestWord ? word.Length : longestWord;
        }

        return longestWord;
    }

    private static int GreatestVowelInAWordCount(string text)
    {
        string[] words = text.Split(" ");
        int longestVowelCount = 0;
        foreach (var word in words)
        {
            int vowelCount = GetVowelCount(word);
            longestVowelCount = vowelCount > longestVowelCount ? vowelCount : longestVowelCount;
        }

        return longestVowelCount;
    }

    private static int GetVowelCount(string word)
    {
        int vowelCount = 0;
        foreach (var character in word)
        {
            if (_vowels.Contains<string>(character.ToString()))
            {
                vowelCount++;
            }
        }
        return vowelCount;
    }
}