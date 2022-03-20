namespace SocialMedia;

public class User
{
    private readonly int _id;
    private readonly string _name;
    private readonly int _age;
    private readonly string _city;
    private List<int> friendIds;

    public int Id => _id;

    public User(int id, string name, int age, string city)
    {
        _id = id;
        _name = name;
        _age = age;
        _city = city;
    }

    public void AddFriend(int userId)
    {
        if (friendIds.Contains(userId)) return;
        friendIds.Add(userId);
    }

    public void RemoveFriend(int userId)
    {
        var friendNotFound = !friendIds.Contains(userId);
        if (friendNotFound) return;
        friendIds.Remove(userId);
    }
    
    public void WriteInfo()
    {
        Console.WriteLine($"Id: {_id}");
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Age: {_age}");
        Console.WriteLine($"City: {_city}");
    }
}