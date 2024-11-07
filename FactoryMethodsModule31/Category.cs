namespace FactoryMethodsModule31;

public abstract class Category
{
    public string Name { get; }

    protected Category(string name) =>
        Name = name;

    public static Category CreateRoot() =>
        new RootCategory();

    public Category SubCategory(string name) =>
        new SubCategory(name, this);

    public override string ToString() => string.Join(" > ", Path.Select(cat => cat.Name).ToArray());

    private IEnumerable<Category> Path => NestingSequence().Reverse().DefaultIfEmpty(this);

    private IEnumerable<Category> NestingSequence()
    {
        var current = this;
        while (current is SubCategory subCategory)
        {
            yield return subCategory;
            current = subCategory.Parent;
        }
    }
}