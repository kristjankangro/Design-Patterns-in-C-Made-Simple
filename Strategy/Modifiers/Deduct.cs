using Strategy.Common;

namespace Strategy.Modifiers;

public class Deduct : IPriceModifier
{
    public Deduct(Money amount) => Amount = amount;

    private Money Amount { get; }

    public (Money first, Money second) ApplyTo(Money price1, Money price2) =>
        (price1, price1 >= Amount
            ? price1 - Amount
            : price1.Currency.Zero);
}