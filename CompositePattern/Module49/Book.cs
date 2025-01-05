namespace CompositePattern.Module49;

public class Book
{
    public string Title { get; }
    public Name Author { get; }

    public Book(string title, Name author)
    {
        Title = title;
        Author = author;
    }

    public override string ToString() =>
        $"{Author.Printable}, {Title}";
}