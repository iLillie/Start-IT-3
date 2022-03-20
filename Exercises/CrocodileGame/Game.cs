namespace CrocodileGame;

public class Game
{
    private readonly Random _random = new Random();
    private int _userScore = 0;
    private const string VALD_CHARACTERS = "<>=";
    private bool hasValidInput = true;
    private string userInput = "";
    private int _numOne = 0;
    private int _numTwo = 0;

    private bool WinConditionOne => _numOne > _numTwo && userInput == ">";
    private bool WinConditionTwo => _numOne < _numTwo && userInput == "<";
    private bool WinConditionThree => _numOne == _numTwo && userInput == "=";
    private int RandomNumber => _random.Next(1, 12);
    private bool ValidInput => VALD_CHARACTERS.Contains(userInput);

    public Game()
    {
    }

    public void StartGame()
    {
        ShowWelcome();
        while (hasValidInput)
        {
            Update();
        }

        ShowScore();
    }

    private void Update()
    {
        GenerateNumbers();
        ShowNumbers();
        userInput = Console.ReadLine();
        hasValidInput = ValidInput;
        UpdateScore();
        ShowScore();
    }

    private void ShowWelcome()
    {
        Console.WriteLine("Welcome to Crocodile Game!");
    }
    private void ShowNumbers()
    {
        Console.WriteLine($"{_numOne}_{_numTwo}");
    }

    private void ShowScore()
    {
        Console.WriteLine($"New score is: {_userScore}");
    }

    private void GenerateNumbers()
    {
        _numOne = RandomNumber;
        _numTwo = RandomNumber;
    }

    private void UpdateScore()
    {
        if (WinConditionOne || WinConditionTwo || WinConditionThree)
        {
            IncreaseUserScore();
            return;
        }

        DecreaseUserScore();
    }

    private void IncreaseUserScore() => _userScore += 1;
    private void DecreaseUserScore() => _userScore -= 1;
}