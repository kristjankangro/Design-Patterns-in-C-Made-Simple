using Strategy.Common;

namespace Strategy.Modifiers;

public class DeductAmount : IPriceModifier
{
    public DeductAmount(Money amount) => Amount = amount;

    private Money Amount { get; }
    public Money ApplyTo(Money price) => price - Amount;
}