using Strategy;
using Strategy.Common;

var deduction = new Money(7, new Currency("USD"));

Apply(TakeTwoOffer.GetOneFree());
Apply(TakeTwoOffer.Deduct(deduction));

return;

void Apply(TakeTwoOffer offer)
{
    var books = Books.GetBooks();
    var cart = offer.ApplyTo(books.first, books.second);
    Console.WriteLine();
    Console.WriteLine(cart.first);
    Console.WriteLine(cart.second);
}
// }