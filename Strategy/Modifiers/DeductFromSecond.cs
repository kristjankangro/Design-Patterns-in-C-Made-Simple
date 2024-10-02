using Strategy.Common;

namespace Strategy.Modifiers;

public class DeductFromSecond : CalculationgModifier
{
    public DeductFromSecond(IDeduction deduction) : base(deduction)
    {
    }

    protected override (Money first, Money second) ApplyTo(Money a, Money b, Money deduction)
        => (a, b >= deduction ? b - deduction : b.Currency.Zero);
}