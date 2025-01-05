namespace CompositePattern.Module52.Names;

public class FirstEtAl : Name 
{
    public FirstEtAl(SingleName first)
    {
        First = first;
    }

    private SingleName First { get; }

    public override string Printable => $"{First.Printable} et al.";
}