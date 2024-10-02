using Strategy;
using Strategy.Modifiers;

OfferCart.Apply(new TakeTwoOffer(new GetOneFree()));
OfferCart.Apply(new TakeTwoOffer(new Deduct(Deduction.Get7())));
OfferCart.Apply(new TakeTwoOffer(new DeductWithSpillOver(Deduction.Get12())));
