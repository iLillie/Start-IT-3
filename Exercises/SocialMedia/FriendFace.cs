namespace SocialMedia;

public class FriendFace
{
    private int _nextUserId = 0;
    private User _loggedInUser;
    private readonly List<User> _users;
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

    private User GetUser(int userId)
    {
        return _users.First(val => val.Id == userId);
    }

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

    private void UpdateNextUserId()
    {
        _nextUserId++;
    }

    public void StartMenu()
    {
        Welcome();
        if (!isLoggedIn)
        {
            Console.WriteLine("User not logged in!");
            return;
        }

        LoggedIn();
        while (isLoggedIn)
        {
            MenuInfo();
            if (Int32.TryParse(Console.ReadLine(), out int selection))
            {
                MenuSelection(selection);
            }
        }
    }

    private void MenuSelection(int index)
    {
        switch (index)
        {
            case 1:
                ViewUsers();
                Console.Write("Select UserId: ");
                var input = Console.ReadLine();
                if (ValidateInput(input))
                {
                    _loggedInUser.AddFriend(Int32.Parse(input));
                }

                break;
            case 2:
                ViewUsers();
                Console.Write("Select UserId: ");
                var input2 = Console.ReadLine();
                if (ValidateInput(input2))
                {
                    _loggedInUser.RemoveFriend(Int32.Parse(input2));
                }

                break;
            case 3:
                Console.WriteLine("Friends: ");
                foreach (var friendId in _loggedInUser.FriendIds)
                {
                    GetUser(friendId).WriteMinimalInfo();
                }

                break;
            case 4:
                Console.WriteLine("Friends: ");
                foreach (var friendId in _loggedInUser.FriendIds)
                {
                    GetUser(friendId).WriteMinimalInfo();
                }

                Console.Write("Select Friend Id: ");
                var input3 = Console.ReadLine();
                if (ValidateInput(input3))
                {
                    GetUser(Int32.Parse(input3)).WriteInfo();
                }

                break;
        }
    }

    private bool ValidateInput(string? validateInput)
    {
        return Int32.TryParse(validateInput, out int _);
    }

    private void MenuInfo()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1: Legg til bruker som venn");
        Console.WriteLine("2: Fjern bruker som venn");
        Console.WriteLine("3: Venner");
        Console.WriteLine("4: Info fra venn");
        Console.WriteLine();
    }


    private void ViewUsers()
    {
        foreach (var user in _users)
        {
            user.WriteMinimalInfo();
        }
    }

    private void LoggedIn()
    {
        Console.WriteLine("UserInfo:");
        _loggedInUser.WriteInfo();
        Console.WriteLine();
    }

    private void Welcome()
    {
        Console.WriteLine("Welcome to Friend Face");
        Console.WriteLine();
    }
}