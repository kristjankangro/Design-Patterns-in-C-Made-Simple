using AbstractFactory.Data;

namespace AbstractFactory.CheapDb
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

        public void Connect(string connectionString) => throw new System.NotImplementedException();

        public void Disconnect() => throw new System.NotImplementedException();

        public object Execute(ICommand command, ITransaction transaction)
        {
            return Execute((Command)command, (Transaction)transaction);
        }

        public object Execute(Command command, Transaction transaction) => SendCommand(command.Text, transaction);

        public  object SendCommand(string commandText) => new object();
        private object SendCommand(string commandText, Transaction transaction) => new object();
    }
}