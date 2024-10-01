namespace Strategy;

public class OfferCart
{
    public static void Apply(TakeTwoOffer offer)
    {
        var books = Books.GetBooks();
        var cart = offer.ApplyTo(books.first, books.second);
        Console.WriteLine();
        Console.WriteLine(cart.first);
        Console.WriteLine(cart.second);
    }
}