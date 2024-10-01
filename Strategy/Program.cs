// See https://aka.ms/new-console-template for more information

using Strategy;
using Strategy.Common;

var deduction = new Money(7, new Currency("USD"));

var book = new Book("Design patterns: Elements of reusable OOP Software",
    new Money( 35, new Currency("USD")));

book = book.WithEffectivePrice(new Money(28, new Currency("USD")));

var book2 = new Book("Little prince", new Money(9, new Currency("USD")));

var offer = TakeTwoOffer.Deduct(deduction, book2, book);

var offer2 = TakeTwoOffer.GetOneFree(book2, book);

var cart = offer.Apply();
Console.WriteLine(cart.first);
Console.WriteLine(cart.second);

cart = offer2.Apply();
Console.WriteLine(cart.first);
Console.WriteLine(cart.second);