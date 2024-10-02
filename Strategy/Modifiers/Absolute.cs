using Strategy;
using Strategy.Common;

public class Absolute : IDeduction
{
    private Money Amount { get; }
    public Absolute(Money amount) => Amount = amount;


    public Money From(Money a, Money b)
    {
        return Amount;
    }
}