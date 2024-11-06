using AbstractFactory.Data;

namespace AbstractFactory.CheapDb
{
    public class CheapTransaction : ITransaction
    {
        private int TransactionId { get; }
        private CheapConnection Connection { get; }

        public CheapTransaction(CheapConnection connection)
        {
            this.Connection = connection;
            this.TransactionId =
                connection.SendCommand("BEGIN TRANSACTION") is int id ? id : -1;
        }

        public void Commit() =>
            this.Connection.SendCommand("COMMIT TRANSACTION");

        public void Rollback() =>
            this.Connection.SendCommand("ROLLBACK TRANSACTION");

        public override string ToString() =>
            $"Transaction(Id={this.TransactionId})";
    }
}
