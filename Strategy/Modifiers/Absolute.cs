using Strategy;
using Strategy.Common;

public class Absolute : IPriceModifier
{
    public Absolute(Money amount)
    {
        Amount = amount;
    }

    private Money Amount { get; }

    public (Money first, Money second) ApplyTo(Money a, Money b)
    {
        return (a, b >= Amount ? b - Amount : b.Currency.Zero);
    }
}