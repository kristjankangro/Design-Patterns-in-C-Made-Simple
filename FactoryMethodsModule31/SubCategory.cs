namespace FactoryMethodsModule31;

public class SubCategory : Category
{
    public Category Parent { get; }
    public SubCategory(string name, Category parent) : base(name) => Parent = parent ?? throw new ArgumentNullException(nameof(parent));
}