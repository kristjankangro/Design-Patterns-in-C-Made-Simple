namespace Strategy;

public class TakeTwoOffer
{
    private Book First { get; }
    private Book Second { get; }

    public TakeTwoOffer(Book first, Book second)
    {
        this.First = first;
        this.Second = second;
    }

    public (Book first, Book second) Apply() => DeductCheaper(7);

    private (Book expensive, Book cheap) Sort =>
        First.Price >= Second.Price ? (First, Second) : (Second, First);

    private (Book first, Book second) DeductCheaper(decimal amount)
    {
        var books = this.Sort;
        return (books.expensive, books.cheap.WithEffectivePrice(
            books.cheap.Price.SubtractAmount(amount)));
    }
    
}