namespace Demo.Clip02.FastDb
{
    public class Connection
    {
        private string Server { get; }
        private string Database { get; }
        private Credentials Credentials { get; }

        public Connection(string server, string database, Credentials credentials)
        {
            this.Server = server;
            this.Database = database;
            this.Credentials = credentials;
        }
    }
}
