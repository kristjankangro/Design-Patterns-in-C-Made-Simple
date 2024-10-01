using Strategy.Common;

namespace Strategy;

public class TakeTwoOffer
{
    private Book First { get; }
    private Book Second { get; }
    private Func<Money, Money> Modify { get; }

    public TakeTwoOffer(Func<Money, Money> modify, Book first, Book second)
    {
        this.First = first;
        this.Second = second;
        Modify = modify;
    }

    public static TakeTwoOffer GetOneFree(Book first, Book second) =>
        new TakeTwoOffer(price => price.Currency.Zero, first, second);
    
    public static TakeTwoOffer Deduct(Money amount, Book first, Book second) =>
        new TakeTwoOffer(price => price - amount, first, second);

    public (Book first, Book second) Apply() => DeductCheaper();

    private (Book expensive, Book cheap) Sort =>
        First.Price >= Second.Price ? (First, Second) : (Second, First);

    private (Book first, Book second) DeductCheaper()
    {
        var books = this.Sort;
        return (books.expensive, books.cheap.WithEffectivePrice(
            Modify(books.cheap.Price)));
    }
}