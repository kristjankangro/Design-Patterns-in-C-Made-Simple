using System.Collections;
using System.Collections.Immutable;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace Demo.Common;

public class WordSet : IEnumerable<string>
{
    private WordSet(IEnumerable<string> skipWords, IImmutableSet<string> content)
    {
        Content = content;
        SkipWords = skipWords;
    }

    private IImmutableSet<string> Content { get; }
    private IEnumerable<string> SkipWords { get; }

    public WordSet(IEnumerable<string> skipWords)
    {
        Content = ImmutableHashSet.Create<string>(StringComparer.OrdinalIgnoreCase);
        SkipWords = skipWords.ToList();
    }


    public WordSet AddText(string text)
    {
        return new WordSet(
            SkipWords,
            Content.Union(BreakIntoWords(text).Where(ShouldRetain))
        );
    }


    private bool ShouldRetain(string word)
    {
        return SkipWords.All(skip => !string.Equals(word, skip, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerator<string> GetEnumerator()
    {
        return Content.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerable<string> BreakIntoWords(string content) =>
        Regex.Matches(content, @"[\p{L}0-9-]+")
            .Select(m => m.Value).Distinct();
}