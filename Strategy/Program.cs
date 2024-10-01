// See https://aka.ms/new-console-template for more information

// protected override void Implementation()
// {
//     this.Apply();
//     this.Apply(TakeTwoOffer.Deduct(new Money(7, new Currency("USD"))));
// }
//
// private void Apply(TakeTwoOffer offer)
// {

using Strategy;
using Strategy.Common;

var deduction = new Money(7, new Currency("USD"));

Book first = new Book(
    "Design Patterns: Elements of Reusable Object-oriented Software",
    new Money(35, new Currency("USD")));
Book second = new Book(
    "The Little Prince",
    new Money(9, new Currency("USD")));

var offer = TakeTwoOffer.GetOneFree();
Apply(first, second, offer);

offer = TakeTwoOffer.Deduct(deduction);
Apply(first, second, offer);

void Apply(Book book, Book second1, TakeTwoOffer offer)
{
    var cart = offer.ApplyTo(book, second1);
    Console.WriteLine();
    Console.WriteLine(cart.first);
    Console.WriteLine(cart.second);
}
// }