using System.Collections.Generic;
using System.Linq;

namespace CompositePattern.Module53.Volumes;

class SeparateVolume : Volume
{
    public string Label { get; }
    public string Title { get; }

    public SeparateVolume(string label, string title)
    {
        this.Label = label;
        this.Title = title;
    }

    public override string GetLabel(string prefix, string suffix) =>
        string.Empty;

    public override IEnumerable<string> GetTitles(int whenMoreThan) => 1 > whenMoreThan ? [this.Title] : [];
}