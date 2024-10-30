using System.Collections.Generic;
using Demo.AbstractFactory.FastDb;

namespace Demo.Clip01.FastDb
{
    public class SelectCommand : Command<IEnumerable<object>>
    {
        public SelectCommand(string commandText) : base(commandText)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<object> Execute(Transaction transaction) => new []{"Jack", "Jack2", "Jack3", "Jack4"};
    }
}