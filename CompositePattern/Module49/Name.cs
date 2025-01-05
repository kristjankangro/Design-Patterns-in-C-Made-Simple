using System.Collections.Generic;
using System.Linq;

namespace CompositePattern.Module49;

public abstract class Name
{
    public abstract string Printable { get; }
}

public class Anonymous : Name
{
    public override string Printable => "Anonymous";
}

public class SingleName : Name
{
    public override string Printable { get; }

    public SingleName(string name) => Printable = name;
}

public class MultiName : Name
{
    public MultiName(IEnumerable<Name> names) => Names = names.ToList();

    private List<Name> Names { get; }

    public override string Printable =>
        string.Join(", ", Names.Select(n => n.Printable).ToArray());
}