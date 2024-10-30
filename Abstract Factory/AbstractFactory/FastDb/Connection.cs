using System.ComponentModel;
using Demo.AbstractFactory.FastDb;
using Demo.AbstractFactory.FastDb.Commands;
using Demo.Clip01.CheapDb;
using Demo.Clip01.Data;
using Transaction = Demo.AbstractFactory.FastDb.Transaction;

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

        public void Connect(string connectionString) => throw new System.NotImplementedException();

        public void Disconnect() => throw new System.NotImplementedException();

        public object Execute(ICommand command, ITransaction transaction)
        {
            return Execute(command, (Transaction)transaction);
        }

        public object Execute(ICommand command, Transaction transaction) => 
            command is SelectCommand select ? select.Execute(transaction)
                : command is InsertCommand insert ? insert.Execute(transaction).key 
                : command is UpdateCommand update ? update.Execute(transaction)
                : command is DeleteCommand delete ? delete.Execute(transaction)
            :throw new InvalidEnumArgumentException();

        public  object SendCommand(string commandText) => new object();
        private object SendCommand(string commandText, Transaction transaction) => new object();
    }
}