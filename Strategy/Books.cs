using Strategy.Common;

namespace Strategy;

public class Books
{
    public static (Book first, Book second) GetBooks()
    {
        return (
            new Book(
                "Design Patterns: Elements of Reusable Object-oriented Software",
                new Money(35, new Currency("USD"))),
            new Book(
                "The Little Prince",
                new Money(9, new Currency("USD"))));
    }
}