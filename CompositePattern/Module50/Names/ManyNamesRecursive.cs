using System.Collections.Generic;
using System.Linq;
using Demo.Clip03;

namespace CompositePattern.Module50.Names
{
    class ManyNamesRecursive : Name
    {
        private List<Name> Names { get; }

        public ManyNamesRecursive(IEnumerable<Name> names)
        {
            this.Names = names.ToList();
        }

        public override string Printable =>
            string.Join(", ", this.Names.Select(name => name.Printable).ToArray());
    }
}