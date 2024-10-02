using Strategy.Common;

namespace Strategy.Modifiers;

public class RelativeToLower : IDeduction
{
    private readonly CalculationgModifier _calculationgModifier;
    private decimal Factor { get; }

    public RelativeToLower(decimal factor)
    {
        this.Factor = 0 <= factor && factor <= 1 ? factor : throw new ArgumentException(nameof(factor));
        _calculationgModifier = new CalculationgModifier(this);
    }

    public Money From(Money a, Money b)
    {
        return Factor * (a < b ? a : b);
    }
}