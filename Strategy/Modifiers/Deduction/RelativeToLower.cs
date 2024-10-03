using Strategy.Common;

namespace Strategy.Modifiers.Deduction
{
    public class RelativeToLower : IDeduction
    {
        private decimal Factor { get; }

        public RelativeToLower(decimal factor) => this.Factor = 0 <= factor && factor <= 1 ? factor : throw new ArgumentException(nameof(factor));

        public Money From(Money a, Money b) 
            => Factor * (a < b ? a : b);
    }
}