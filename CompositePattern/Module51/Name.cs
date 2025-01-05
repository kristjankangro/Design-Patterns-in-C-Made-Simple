using System.Linq;
using Demo.Clip04.Names;

namespace CompositePattern.Module51
{
    public abstract class Name
    {
        public abstract string Printable { get; }
        public static Name Anon => new Anonymous();

        public static Name Create(string name, params string[] others) =>
            others.Length == 0
                ? (Name)new SingleName(name)
                : new ManyNames(new[] { name }.Concat(others).Select(n => new SingleName(n)));
    }
}