using System.Collections.Generic;
using System.Linq;

namespace CompositePattern.Module49.Names;

public class MultiName : Name
{
    public MultiName(IEnumerable<Name> names) => Names = names.ToList();

    private List<Name> Names { get; }

    public override string Printable =>
        string.Join(", ", Names.Select(n => n.Printable).ToArray());
}