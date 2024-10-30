using Demo.Clip01.Data;

namespace Demo.Clip01.FastDb
{
    public class Connection : IConnection
    {
        private string ServerName { get; }
        private string Database { get; }
        private Credentials Credentials { get; }

        public Connection(string serverName, string database, Credentials credentials)
        {
            ServerName = serverName;
            Database = database;
            Credentials = credentials;
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