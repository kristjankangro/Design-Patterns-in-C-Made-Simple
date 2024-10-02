using Strategy.Common;

namespace Strategy.Modifiers;

public class Proportional : CalculationgModifier
{
    public Proportional(IDeduction deduction) : base(deduction)
    {
    }

    protected override (Money first, Money second) ApplyTo(Money a, Money b, Money deduction)
    {
        decimal factor = b / (a + b);
        Money bDeduction = deduction * factor;
    }
}