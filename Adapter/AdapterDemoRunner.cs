using Demo.Clip01.Abstractions;
using Demo.Common;

namespace Demo.Clip01
{
    
    
    class AdapterDemoRunner : Common.Demo
    {

        private IEnumerable<string> SkipWordsEN { get; } = new[]
        {
            "and", "or"
        };
        
        private IEnumerable<string> SkipWordsET { get; } = new[]
        {
            "ja", "või"
        };

        private Func<WordSet> GetWordSetFactory(IEnumerable<string> skipwords) => () => new WordSet(skipwords);
        protected override int ClipNumber { get; } = 1;
        protected override void Implementation()
        {
            var index = new KeywordIndex<IWithKeywords>();
            var item1 = new Book(
                "Largest book ever",
                "long",
                "boring");
            var video = new Video("the long, long video with ad", "seda-keyd-pole");
            
            
            var repo = new KeywordsRepository();

            IWithKeywords item2 = new PresetKeywords(
                new VideoKeywords(video, GetWordSetFactory(SkipWordsEN)),
                repo.FindFor(video.Handle)
            );
            
            
            var video2 = new Video("Tuulest toodud", "see-key-on");

            IWithKeywords item3 = new PresetKeywords(
                new VideoKeywords(video2, GetWordSetFactory(SkipWordsET)),
                repo.FindFor(video2.Handle));
            
            
            index.Add(item1);
            index.Add(item2);
            index.Add(item3);
            Console.WriteLine(index);
            Console.WriteLine();

            var q = "long";
            IEnumerable<IWithKeywords> results = index.FindApproximate(q);
            Console.WriteLine($"Search for '{q}': {results.ToSequenceString(", ")}");
        }
        
    }
}
