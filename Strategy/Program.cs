using Strategy;
using Strategy.Modifiers;

OfferCart.Apply(new TakeTwoOffer(new GetOneFree()));
OfferCart.Apply(new TakeTwoOffer(new DeductAmount(Deduction.GetActive())));
