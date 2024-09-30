// See https://aka.ms/new-console-template for more information

using System.Data.SqlTypes;
using Demo.Clip01;
using Strategy;
using Strategy.Common;

var book = new Book("Design patterns: Elements of reusable OOP Software",
    new Money( 35, new Currency("USD")));
Console.WriteLine("Hello, World!");