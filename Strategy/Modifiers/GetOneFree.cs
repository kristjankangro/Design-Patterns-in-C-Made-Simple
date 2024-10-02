using Strategy.Common;

namespace Strategy.Modifiers;

public class GetOneFree : IPriceModifier
{
    public Money ApplyTo(Money price) => price.Currency.Zero;
}