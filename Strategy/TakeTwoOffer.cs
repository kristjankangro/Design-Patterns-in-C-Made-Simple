using Strategy;
using Strategy.Common;

public class TakeTwoOffer
{
    private Func<Money, Money> Modify { get; }

    public TakeTwoOffer(Func<Money, Money> modify)
    {
        this.Modify = modify;
    }

    public static TakeTwoOffer GetOneFree() =>
        new TakeTwoOffer(price => price.Currency.Zero);

    public static TakeTwoOffer Deduct(Money amount) =>
        new TakeTwoOffer(price => price - amount);

    public (Book first, Book second) ApplyTo(Book first, Book second) =>
        this.DeductFromCheaper(first, second);

    private (Book first, Book second) DeductFromCheaper(Book first, Book second)
    {
        var books = this.Sort(first, second);
        return (
            books.expensive,
            books.cheap.WithEffectivePrice(this.Modify(books.cheap.Price)));
    }

    private (Book expensive, Book cheap) Sort(Book first, Book second) =>
        first.Price >= second.Price
            ? (first, second)
            : (second, first);
}