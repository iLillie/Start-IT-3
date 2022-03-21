namespace SocialMedia;

public class User
{
    private readonly string _name;
    private readonly int _age;
    private readonly string _city;

    public int Id { get; }
    public List<int> FriendIds { get; }

    public User(int id, string name, int age, string city)
    {
        Id = id;
        _name = name;
        _age = age;
        _city = city;
        FriendIds = new List<int>();
    }

    public void AddFriend(int userId)
    {
        if (FriendIds.Contains(userId)) return;
        FriendIds.Add(userId);
    }
    
    public void RemoveFriend(int userId)
    {
        var friendNotFound = !FriendIds.Contains(userId);
        if (friendNotFound) return;
        FriendIds.Remove(userId);
    }
    
    public void WriteInfo()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Age: {_age}");
        Console.WriteLine($"City: {_city}");
    }

    public void WriteMinimalInfo()
    {
        Console.WriteLine($"{Id}: {_name}");
    }
}