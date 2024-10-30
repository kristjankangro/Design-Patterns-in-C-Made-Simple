using Demo.Clip01.Data;

namespace Demo.Clip01.FastDb
{
    public class FastDBAcess : IDataAccess
    {
        public IConnection CreateConnection(string connectionString)
        {
            return CreateConnection(new ConnectionData(connectionString));
        }

        private IConnection CreateConnection(ConnectionData data)
        {
            return new Connection(data.Server, data.Database, data.Credentials);
        }


        public ICommand CreateCommand(string commandText)
        {
            throw new System.NotImplementedException();
        }

        public ITransaction CreateTransaction(IConnection connection)
        {
            throw new System.NotImplementedException();
        }
    }
}