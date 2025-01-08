using System.Collections.Generic;
using System.Linq;

namespace CompositePattern.Module53.Volumes;

class MultipleVolumes : Volume
{
    private List<SeparateVolume> Volumes { get; }

    public MultipleVolumes(IEnumerable<SeparateVolume> volumes) => 
        this.Volumes = volumes.ToList();

    public override string GetLabel(string prefix, string suffix) =>
        $"{prefix}{this.FirstLabel}-{this.LastLabel}{suffix}";

    public override IEnumerable<string> GetTitles(int whenMoreThan) => 
        this.Volumes.Count > whenMoreThan ? this.Volumes.Select(v => v.Title) : [];

    private string FirstLabel =>
        this.Volumes.First().Label;

    private string LastLabel =>
        this.Volumes.Last().Label;
}