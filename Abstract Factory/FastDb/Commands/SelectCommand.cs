using System.Collections.Generic;

namespace AbstractFactory.FastDb.Commands
{
    class SelectCommand : FastCommand<IEnumerable<object>>
    {
        public SelectCommand(string commandText) : base(commandText)
        {
        }

        public override IEnumerable<object> Execute(FastTransaction transaction) =>
            new[] {"Jack", "Joe", "Jill"};
    }
}
