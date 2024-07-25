using Demo.Clip01.Abstractions;
using Demo.Common;

namespace Demo.Clip01;

public class VideoKeywords : IWithKeywords, IEquatable<IWithKeywords>
{
    private IEquatable<IWithKeywords> _equatableImplementation;

    public VideoKeywords(Video target, Func<WordSet> createWordSet)
    {
        Target = target;
        CreateWordSet = createWordSet;
    }

    private Video Target { get; }

    public IEnumerable<string> Keywords => CreateWordSet().AddText(Target.Title);

    private Func<WordSet> CreateWordSet { get; }

    public override bool Equals(object obj) =>
        obj is VideoKeywords keywords && this.Equals(keywords);

    public bool Equals(IWithKeywords other) =>
        other is VideoKeywords keywords && this.Equals(keywords);

    public override string ToString()
    {
        return Target.ToString() ?? String.Empty;
    }

    public override int GetHashCode() =>
        this.Target.GetHashCode();
}