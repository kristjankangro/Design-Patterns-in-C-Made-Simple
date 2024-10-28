using Demo.Clip01.Data;

namespace Demo.Clip01.FastDb
{
    public class Connection
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
    }
}