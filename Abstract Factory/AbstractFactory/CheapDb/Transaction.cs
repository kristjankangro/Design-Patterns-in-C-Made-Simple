using Demo.Clip01.Data;

namespace Demo.Clip01.CheapDb
{
    public class Transaction : ITransaction
    {
        private int TransactionId { get; }
        private Connection Connection { get; }

        public Transaction(Connection connection)
        {
            Connection = connection;
            TransactionId = (int)connection.SendCommand("Begin Transaction");
        }

        public void Commit() => Connection.SendCommand("Commit Transaction");

        public void Rollback() => Connection.SendCommand("Rollback Transaction");

        public override string ToString() => $"TransactionId:(Id={TransactionId})";
    }
}