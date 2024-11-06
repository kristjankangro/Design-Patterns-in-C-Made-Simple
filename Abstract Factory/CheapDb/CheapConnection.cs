using AbstractFactory.Data;

namespace AbstractFactory.CheapDb
{
    public class CheapConnection : IConnection
    {
        private string Database { get; }
        private string UserName { get; }
        private string Password { get; }

        public CheapConnection(string database, string userName, string password)
        {
            this.Database = database;
            this.UserName = userName;
            this.Password = password;
        }

        public void Connect() { }

        public void Disconnect() { }

        public object Execute(ICommand command, ITransaction transaction) =>
            this.Execute((CheapCommand) command, (CheapTransaction) transaction);

        public ITransaction BeginTransaction() => new CheapTransaction(this);

        public object Execute(CheapCommand command, CheapTransaction transaction) =>
            this.SendCommand(command.Text, transaction);

        public object SendCommand(string text) => 
            new object();

        public object SendCommand(string text, CheapTransaction transaction) => 
            new object();
    }
}
