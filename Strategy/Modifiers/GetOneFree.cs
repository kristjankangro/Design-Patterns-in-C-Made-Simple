using Microsoft.VisualBasic;
using Strategy.Common;

namespace Strategy.Modifiers;

public class GetOneFree : IPriceModifier
{
    public (Money first, Money second) ApplyTo(Money price1, Money price2) => (price1, price2.Currency.Zero);
}