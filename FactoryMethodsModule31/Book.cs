namespace FactoryMethodsModule31;

public class Book
{
    public string Title { get; }
    public Category Category { get; }

    public Book(string title, Category category)
    {
        Title = title;
        Category = category ?? throw new ArgumentNullException(nameof(category));
    }

    public override string ToString() => $"{Category} {Title}";
}