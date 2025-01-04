using System;

namespace CompositePattern.Module48;

class Clip01Demo : Demo.Common.Demo
{
    protected override void Implementation()
    {
        try
        {
            Book littlePrince = new Book(
                "The Little Prince",
                "Antoine de Saint-Exupéry");

            Book oosc = new Book(
                "Object-Oriented Software Construction",
                "Bertrand Meyer");  
            
            Book dp = new Book(
                "Design Patterns",
                "Erich Gamma", "Richard Helm", "Ralph Johnson", "John Vlissides");  
            
            Book tn = new Book(
                "1001 Nights", "Anonymous");

            Console.WriteLine(littlePrince);
            Console.WriteLine(oosc);
            Console.WriteLine(dp);
            Console.WriteLine(tn);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }
}