using Microsoft.VisualBasic;
using Strategy.Common;

namespace Strategy.Modifiers;

public class GetOneFree : IPriceModifier
{
    public (Money first, Money second) ApplyTo(Money a, Money b) => (a, b.Currency.Zero);
}