using Strategy;
using Strategy.Modifiers;

OfferCart.Apply(new TakeTwoOffer(new GetOneFree()));
OfferCart.Apply(new TakeTwoOffer(new Absolute(DeductionRepo.Get7())));
OfferCart.Apply(new TakeTwoOffer(new AbsoluteWithSpillover(DeductionRepo.Get12())));
