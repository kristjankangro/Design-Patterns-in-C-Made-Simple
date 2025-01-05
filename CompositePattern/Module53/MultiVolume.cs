using System.Collections.Generic;
using System.Linq;

namespace CompositePattern.Module53;

public class MultiVolume : Volume
{
    public MultiVolume(IEnumerable<SeparateVolume> volumes) => Volumes = volumes.ToList();

    private List<SeparateVolume> Volumes { get; }

    public override string GetLabel(string prefix, string suffix) => $"{prefix}{FirstLabel}-{LastLabel}{suffix}";
    private string LastLabel => Volumes.Last().Label;
    private string FirstLabel => Volumes.First().Label;
}