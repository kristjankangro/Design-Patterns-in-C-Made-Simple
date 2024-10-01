// See https://aka.ms/new-console-template for more information

using Strategy;
using Strategy.Common;

var book = new Book("Design patterns: Elements of reusable OOP Software",
    new Money( 35, new Currency("USD")));

book = book.WithEffectivePrice(new Money(28, new Currency("USD")));

var another = new Book("Little prince", new Money(9, new Currency("USD")));

var offer = new TakeTwoOffer(another, book);

var cart = offer.Apply();
Console.WriteLine(cart.first);
Console.WriteLine(cart.second);