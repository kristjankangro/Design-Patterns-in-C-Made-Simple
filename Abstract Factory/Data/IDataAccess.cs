namespace AbstractFactory.Data
{
    public interface IDataAccess
    {
        IConnection CreateConnection(string connectionString);
        ITransaction CreateTransaction(IConnection connection);
        ICommand CreateCommand(string commandText);
    }
}