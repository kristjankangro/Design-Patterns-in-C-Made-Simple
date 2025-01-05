using System.Linq;
using CompositePattern.Module52.Names;
using Anonymous = CompositePattern.Module52.Names.Anonymous;

namespace CompositePattern.Module52;

public class ScientificNames : INameFactory
{
    private int MaxNames { get; }
    public ScientificNames(int maxNames) => MaxNames = maxNames;
    public Name Anonymous => new Anonymous();

    public Name Create(string first, params string[] others)
        => 1 + others.Length > MaxNames
            ? new FirstEtAl(new ScientificName(first))
            : others.Length == 0
                ? new ScientificName(first)
                : new ManyNames(
                    new[] { first }.Concat(others).Select(n => new ScientificName(n)));
}