namespace CompositePattern.Module49.Names;

public class SingleName : Name
{
    public override string Printable { get; }

    public SingleName(string name) => Printable = name;
}