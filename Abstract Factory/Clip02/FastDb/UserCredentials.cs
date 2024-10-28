namespace Demo.Clip02.FastDb
{
    public class UserCredentials : Credentials
    {
        public string UserName { get; }
        public string Password { get; }

        public UserCredentials(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }
    }
}
