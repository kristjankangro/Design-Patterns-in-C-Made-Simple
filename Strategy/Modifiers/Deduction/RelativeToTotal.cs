using Strategy.Common;

namespace Strategy.Modifiers.Deduction
{
    public class RelativeToTotal : IDeduction
    {
        private decimal Factor { get; }

        public RelativeToTotal(decimal factor) =>
            Factor = 0 <= factor && factor <= 1 ? factor : throw new ArgumentException(nameof(factor));

        public Money From(Money a, Money b) =>
            Factor * (a + b);
    }
}