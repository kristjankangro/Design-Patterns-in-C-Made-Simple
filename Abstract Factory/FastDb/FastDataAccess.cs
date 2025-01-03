using AbstractFactory.Data;
using AbstractFactory.FastDb.Commands;

namespace AbstractFactory.FastDb
{
    public class FastDataAccess : IDataAccess
    {
        public IConnection CreateConnection(string connectionString) => CreateConnection(new ConnectionData(connectionString));

        private IConnection CreateConnection(ConnectionData data) => new FastConnection(data.Server, data.Database, data.Credentials);

        public ICommand CreateCommand(string commandText) =>
            commandText.StartsWith("INSERT INTO ") ? new InsertCommand(commandText)
            : commandText.StartsWith("DELETE FROM ") ? new DeleteCommand(commandText)
            : commandText.StartsWith("UPDATE ") ? (ICommand)new UpdateCommand(commandText)
            : new SelectCommand(commandText);
    }
}