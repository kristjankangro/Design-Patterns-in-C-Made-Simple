using Strategy;

OfferCart.Apply(TakeTwoOffer.GetOneFree());
OfferCart.Apply(TakeTwoOffer.Deduct(Deduction.GetActive()));
