using Strategy.Common;

namespace Strategy;

public interface IPriceModifier
{
    Money ApplyTo(Money price);
}