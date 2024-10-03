namespace Strategy;

public class BookTitleComparer : IEqualityComparer<Book>
{
    
    private IEqualityComparer<string> TitleComparer { get; } = StringComparer.OrdinalIgnoreCase;
    public bool Equals(Book? x, Book? y) => TitleComparer.Equals(x?.Title, y?.Title);

    public int GetHashCode(Book obj) => TitleComparer.GetHashCode(obj.Title);
}