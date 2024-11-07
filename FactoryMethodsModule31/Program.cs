
using FactoryMethodsModule31;

internal class Program
{
    public static void Main(string[] args)
    {
        var all = Category.CreateRoot();
        var computers = all.SubCategory("Computers");
        var fiction = all.SubCategory("Fiction");
        var fables = all.SubCategory("Fables");
        var peotry = all.SubCategory("Peotry");

        Book desingP = new Book("Desing patterns", computers);
        Book oop = new Book("OOP principles", computers);
        Book little = new Book("Little prince", fables);
        Book raven = new Book("The Raven", peotry);
        Console.WriteLine();
        Print(desingP, oop, little, raven);

        static void Print(params Book[] books) => books.ToList().ForEach(Console.WriteLine);
    }
}