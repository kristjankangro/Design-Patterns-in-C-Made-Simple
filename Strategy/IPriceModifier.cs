using Strategy.Common;

namespace Strategy
{
    public interface IPriceModifier
    {
        (Money first, Money second) ApplyTo(Money a, Money b);
    }
}