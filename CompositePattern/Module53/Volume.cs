using System.Linq;
using Demo.Clip06.Volumes;

namespace CompositePattern.Module53;

public abstract class Volume
{
    public abstract string GetLabel(string prefix, string suffix);

    public static Volume Create((string label, string title) first, params (string label, string title)[] additional)
    {
        return additional.Length == 0
            ? new Demo.Clip06.Volumes.SeparateVolume(first.label, first.title)
            : new MultipleVolumes(new[] { first }.Concat(additional).Select(t => new Demo.Clip06.Volumes.SeparateVolume(t.label, t.title)));
    }
}