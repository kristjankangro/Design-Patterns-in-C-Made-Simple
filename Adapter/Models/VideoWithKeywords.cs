using Demo.Clip01.Abstractions;

namespace Demo.Clip01;

public class VideoWithKeywords : IWithKeywords
{
    public VideoWithKeywords(Video target)
    {
        Target = target;
    }

    private Video Target { get; }
    public IEnumerable<string> Keywords => Target.Title.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Where(k => k.Length > 3);
    public override string ToString()
    {
        return Target.ToString() ?? String.Empty;
    }
}