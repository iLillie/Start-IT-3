namespace SocialMedia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var friendFace = new FriendFace();
            var userOneId = friendFace.NewUser("Lillie", 20, "Horten");
            var userTwoId = friendFace.NewUser("FriendOne", 20, "Horten");
            var userThreeId = friendFace.NewUser("FriendTwo", 20, "Horten");

            friendFace.LoginAsUser(userOneId);
            friendFace.StartMenu();
        }
    }
}