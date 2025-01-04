using System;
using FluentBuilder.Clip05;

namespace FluentBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            new Clip05Demo().Run();

            Console.WriteLine();
            Console.Write("Press ENTER to continue . . . ");
            Console.ReadLine();
        }
    }
}
