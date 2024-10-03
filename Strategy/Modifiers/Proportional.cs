using Strategy.Common;

namespace Strategy.Modifiers
{
    public class Proportional : CalculatingModifier
    {
        public Proportional(IDeduction deduction) : base(deduction)
        {
        }

        protected override (Money first, Money second) ApplyTo(Money a, Money b, Money amount)
        {
            var factor = b / (a + b);
            var bDeduction = CalcDeduction(b, amount * factor);
            var aDeduction = CalcDeduction(a, amount - bDeduction);
            return (a - aDeduction, b - bDeduction);
        }

        private static Money CalcDeduction(Money price, Money amount) => price >= amount ? amount : price;
    }
}