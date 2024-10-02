using Strategy.Common;

namespace Strategy;

public interface IPriceModifier
{
    (Money first, Money second) ApplyTo(Money price1, Money price2);
}