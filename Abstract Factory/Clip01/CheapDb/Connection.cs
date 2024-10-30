using Demo.Clip01.Data;
using Demo.Clip01.FastDb;

namespace Demo.Clip01.CheapDb
{
    public class Connection : IConnection
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

        public void Connect(string connectionString)
        {
            throw new System.NotImplementedException();
        }

        public void Disconnect()
        {
            throw new System.NotImplementedException();
        }

        public object Execute(ICommand command, ITransaction transaction)
        {
            throw new System.NotImplementedException();
        }
    }
}