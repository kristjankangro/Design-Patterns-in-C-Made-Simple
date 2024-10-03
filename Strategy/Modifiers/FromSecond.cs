using Strategy.Common;

namespace Strategy.Modifiers
{
    public class FromSecond : CalculatingModifier
    {
        public FromSecond(IDeduction deduction) : base(deduction)
        {
        }

        protected override (Money first, Money second) ApplyTo(Money a, Money b, Money amount)
            => (a, b >= amount ? b - amount : b.Currency.Zero);
    }
}