namespace SocialMedia;

public class FriendFace
{
    private int _nextUserId = 0;
    private User _loggedInUser;
    private List<User> _users;
    private bool isLoggedIn => _loggedInUser is not null;
    public FriendFace()
    {
        _loggedInUser = null;
        _users = new List<User>();
    }

    public void LoginAsUser(int userId)
    {
        _loggedInUser = GetUser(userId);
    }

    private User GetUser(int userId) => _users.First(val => val.Id == userId);

    public int NewUser(string name, int age, string city)
    {
        try
        {
            var newUser = new User(_nextUserId, name, age, city);
            _users.Add(newUser);
            return _nextUserId;
        }
        finally
        {
            UpdateNextUserId();
        }
    }

    private int UpdateNextUserId() => _nextUserId++;

    public void StartMenu()
    {
        Welcome();    
        if (!isLoggedIn)
        {
            ErrorNotLoggedIn();
            return;
        }
        LoggedIn();
        while (isLoggedIn)
        {
            
        }
    }

    private void MenuSelection(int index)
    {
        
    }

    private void ErrorNotLoggedIn()
    {
        Console.WriteLine("User not logged in!");
    }

    private void LoggedIn()
    {
        Console.WriteLine("UserInfo:");
        _loggedInUser.WriteInfo();
    }

    private void Welcome()
    {
        Console.WriteLine("Welcome to Friend Face");
    }

}