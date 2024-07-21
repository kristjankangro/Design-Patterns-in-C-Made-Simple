using Demo.Common;

namespace Demo.Clip01
{
    class Clip01Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 1;
        protected override void Implementation()
        {
            var index = new KeywordIndex<Book>();
            var book = new Book(
                "Largest book ever",
                "long",
                "boring");

            var video = new Video("Longest video ever");
            index.Add(book);
            Console.WriteLine(index);
            Console.WriteLine();

            var q = "long";
            IEnumerable<Book> results = index.Find(q);
            Console.WriteLine($"Search for '{q}': {results.ToSequenceString(", ")}");
        }
        
    }
}
