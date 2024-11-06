using System;

namespace AbstractFactory.FastDb.Commands
{
    class InsertCommand : FastCommand<(object key, Type keyType)>
    {
        public InsertCommand(string commandText) : base(commandText)
        {
        }

        public override (object key, Type keyType) Execute(FastTransaction transaction) =>
            (17, typeof(int));
    }
}