namespace Konsollapp.Exercise;

public static class PlayersExercise
{
    public static void Run()
    {
        var random = new Random();
        var players = new[] {new Player("Per", 10), new Player("Pål", 10), new Player("Espen", 10)};
        for (var round = 1; round <= 10; round++)
        {
            var playerIndex1 = random.Next(players.Length);
            var playerIndex2 = (playerIndex1 + 1 + random.Next(2)) % players.Length;
            var player1 = players[playerIndex1];
            var player2 = players[playerIndex2];
            player1.Play(player2);
        }

        foreach (var player in players)
        {
            player.ShowNameAndPoints();
        }
    }
}

public class Player
{
    private readonly Random _random = new Random();

    public Player(string name, int points)
    {
        Name = name;
        Points = points;
    }

    private string Name { get; set; }

    private int Points { get; set; }

    private void LosePoints() => Points -= 1;

    private void WinPoints() => Points += 1;

    public void Play(Player opponent)
    {
        var randomNum = _random.Next(0, 2);
        var opponentLost = randomNum == 1;

        if (opponentLost)
        {
            this.WinPoints();
            opponent.LosePoints();
            return;
        }

        this.LosePoints();
        opponent.WinPoints();
    }

    public void ShowNameAndPoints()
    {
        Console.WriteLine($@"{Name} has {Points}");
    }
}