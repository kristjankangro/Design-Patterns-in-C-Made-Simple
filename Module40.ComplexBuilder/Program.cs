using System;
using ComplexBuilder.ComplexBuilders;
using Demo.Clip01;

namespace ComplexBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            new Clip01Demo().Run();

            Console.WriteLine();
            Console.Write("Press ENTER to continue . . . ");
            Console.ReadLine();
        }
    }
}
