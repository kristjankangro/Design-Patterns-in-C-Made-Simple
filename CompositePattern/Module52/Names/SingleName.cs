namespace CompositePattern.Module52.Names
{
    public class SingleName : Name
    {
        public override string Printable { get; }
     
        public SingleName(string name)
        {
            this.Printable = name;
        }
    }
}