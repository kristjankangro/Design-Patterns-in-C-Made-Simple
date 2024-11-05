using System;
using AbstractFactory.Data;

namespace AbstractFactory.FastDb
{
    public class Transaction : ITransaction
    {
        private Guid Id { get; } = Guid.NewGuid();

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