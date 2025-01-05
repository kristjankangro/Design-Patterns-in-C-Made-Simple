namespace CompositePattern.Module53;

public class SeparateVolume : Volume
{
    public string Label { get;  }
    public string Title { get; }

    public SeparateVolume(string label, string title)
    {
        Label = label;
        Title = title;
    }

    public override string GetLabel(string prefix, string suffix)
    {
        return string.Empty;
    }
}