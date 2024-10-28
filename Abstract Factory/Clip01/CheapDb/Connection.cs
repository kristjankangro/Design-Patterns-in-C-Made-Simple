using Demo.Clip01.FastDb;

namespace Demo.Clip01.CheapDb
{
    public class Connection
    {
        private string Database { get; }
        public string Username { get; }
        public string Password { get; }

        public Connection(string database, string username, string password)
        {
            Database = database;
            Username = username;
            Password = password;
        }
    }
}