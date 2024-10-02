using Strategy.Common;

namespace Strategy.Modifiers;

public class DeductWithSpillOver : IPriceModifier
{
    public DeductWithSpillOver(Money amount) => Amount = amount;

    private Money Amount { get; }

    public (Money first, Money second) ApplyTo(Money price1, Money price2)
    {
        var deducts = GetDeductionAndSpill(price2);
        return (price1 - deducts.spill, price2 - deducts.deduct);
    }

    private (Money deduct, Money spill) GetDeductionAndSpill(Money price)
    {
        var deduct = price >= Amount ? Amount : price;
        var spill = Amount - deduct;
        return (deduct, spill);
    }
}