using Strategy;
using Strategy.Modifiers;
using Strategy.Modifiers.Deduction;

var priceModifiers = new List<IPriceModifier>()
{
    new GetSecondFree(),
    new FromSecond(new Absolute(DeductionRepo.Get(7))),
    new FromSecondWithSpillover(new Absolute(DeductionRepo.Get(12))),
    new FromSecondWithSpillover(new RelativeToTotal(.1M)),
    new FromSecondWithSpillover(new RelativeToTotal(.25M)),
    new Proportional(new Absolute(DeductionRepo.Get(12))),
    
};

foreach (var priceModifier in priceModifiers) 
    OfferCart.Apply(new TakeTwoOffer(priceModifier));