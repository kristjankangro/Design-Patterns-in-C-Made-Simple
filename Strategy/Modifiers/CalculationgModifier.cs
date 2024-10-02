using Strategy.Common;

namespace Strategy.Modifiers;

public abstract class CalculationgModifier : IPriceModifier
{
    private IDeduction Deduction { get; }

    public CalculationgModifier(IDeduction deduction) => Deduction = deduction;

    public (Money first, Money second) ApplyTo(Money a, Money b) =>
        this.ApplyTo(a, b, Deduction.From(a, b));

    protected abstract (Money first, Money second) ApplyTo(Money a, Money b, Money deduction);
}