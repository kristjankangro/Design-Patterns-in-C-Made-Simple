using Demo.Clip01.Abstractions;
using Demo.Common;

namespace Demo.Clip01
{
    class AdapterDemoRunner : Common.Demo
    {
        protected override int ClipNumber { get; } = 1;
        protected override void Implementation()
        {
            var index = new KeywordIndex<IWithKeywords>();
            var book = new Book(
                "Largest book ever",
                "long",
                "boring");

            var video = new Video("Longest video ever");
            var video2 = new VideoWithKeywords(video);
            index.Add(book);
            index.Add(video2);
            Console.WriteLine(index);
            Console.WriteLine();

            var q = "long";
            IEnumerable<IWithKeywords> results = index.FindApproximate(q);
            Console.WriteLine($"Search for '{q}': {results.ToSequenceString(", ")}");
        }
        
    }
}
