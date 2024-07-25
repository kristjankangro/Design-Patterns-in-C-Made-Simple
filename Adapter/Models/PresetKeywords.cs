using Demo.Clip01.Abstractions;

namespace Demo.Clip01;

public class PresetKeywords : IWithKeywords, IEquatable<IWithKeywords>
{
    public PresetKeywords(IWithKeywords target, IEnumerable<string> substituteKeywords)
    {
        Target = target;
        SubstituteKeywords = substituteKeywords.ToList();
    }

    private IWithKeywords Target { get; }
    private IEnumerable<string> SubstituteKeywords { get; }
    public IEnumerable<string> Keywords => SubstituteKeywords.Any() ? SubstituteKeywords : Target.Keywords;
    public bool Equals(IWithKeywords? other)
    {
        return other is PresetKeywords preset && Equals(preset);
    }
    
    public override string ToString()
    {
        return Target.ToString() ?? string.Empty;
    }
}