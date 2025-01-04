using System.Linq;

namespace CompositePattern.Module48
{
    public class Book
    {
        public string Title { get; }
        public string[] Authors { get; }

        public Book(string title, string author, params string[] otherAuthors)
        {
            this.Title = title;
            this.Authors = new[] { author }.Concat(otherAuthors).ToArray();
        }

        public override string ToString() =>
            $"{AuthorsToString}, {this.Title}";

        private string AuthorsToString =>
            Authors.Length switch
            {
                0 => "Anonymous",
                1 => Authors[0],
                2 => $"{Authors[0]}, {Authors[1]}",
                _ => $"{Authors[0]} et al."
            };
    }
}