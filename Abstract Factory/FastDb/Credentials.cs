namespace AbstractFactory.FastDb
{
    public class UserCredentials : Credentials
    {
        public string Username { get; }
        public string Password { get; }
        
        public UserCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
    public abstract class Credentials
    {
    }
}