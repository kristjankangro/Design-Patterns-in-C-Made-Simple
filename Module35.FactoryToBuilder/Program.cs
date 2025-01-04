using System;
using FluentBuilder.Clip02;

namespace FluentBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            new Clip02Demo().Run();

            Console.WriteLine();
            Console.Write("Press ENTER to continue . . . ");
            Console.ReadLine();
        }
    }
}
