using System.Collections.Generic;
using System.Linq;
using CompositePattern.Module53.Volumes;

namespace CompositePattern.Module53;

public abstract class Volume
{
    public abstract string GetLabel(string prefix, string suffix);
    public abstract IEnumerable<string> GetTitles(int whenMoreThan);

    public static Volume Create((string label, string title) first, params (string label, string title)[] additional)
    {
        return additional.Length == 0
            ? new SeparateVolume(first.label, first.title)
            : new MultipleVolumes(new[] { first }.Concat(additional).Select(t => new SeparateVolume(t.label, t.title)));
    }
}