using System.Linq;
using CompositePattern.Module52.Names;

namespace CompositePattern.Module52;

public class CommonNames : INameFactory
{
    public Name Anonymous => new Anonymous();

    public Name Create(string first, params string[] others)
        => others.Length == 0
            ? (Name)new SingleName(first)
            : new ManyNames(
                new[] { first }.Concat(others).Select(n => new SingleName(n)));
}