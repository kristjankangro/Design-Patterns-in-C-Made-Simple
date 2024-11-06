using System;
using AbstractFactory.Data;

namespace AbstractFactory.FastDb
{
    class FastTransaction : ITransaction
    {
        private Guid Id { get; } = Guid.NewGuid();

        public FastTransaction(FastConnection connection)
        {
        }

        public void Commit()
        {
        }

        public void Rollback()
        {
        }

        public override string ToString() =>
            $"Transaction(Id={this.Id})";
    }
}