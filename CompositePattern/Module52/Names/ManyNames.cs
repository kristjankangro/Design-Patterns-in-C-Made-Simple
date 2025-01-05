using System.Collections.Generic;
using System.Linq;

namespace CompositePattern.Module52.Names
{
    class ManyNames : Name
    {
        private List<SingleName> Names { get; }

        public ManyNames(IEnumerable<SingleName> names)
        {
            this.Names = names.ToList();
        }

        public override string Printable =>
            string.Join(", ", this.Names.Select(name => name.Printable).ToArray());
    }
}