namespace CompositePattern.Module52.Names
{
    public class ScientificName : SingleName
    {
        public override string Printable => Format(base.Printable.Split(" ", 2));

        private string Format(string[] segments) => $"{segments[1]} {segments[0][0]}";

        public ScientificName(string name) : base(name)
        {
        }
    }
}