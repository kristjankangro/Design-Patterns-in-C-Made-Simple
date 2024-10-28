using Demo.Clip01.Data;

namespace Demo.Clip01.FastDb
{
    public class FastDBAcess : IDataAccess
    {
        public IConnection CreateConnection(string connectionString)
        {
            return new Connection();
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