using System;
using Demo.AbstractFactory.FastDb;

namespace Demo.Clip01.FastDb
{
    public class InsertCommand : Command<(object key, Type keyType)>
    {
        public InsertCommand(string commandText) : base(commandText)
        {
        }

        public override (object key, Type keyType) Execute(Transaction transaction) => (17, typeof(int));
    }
}