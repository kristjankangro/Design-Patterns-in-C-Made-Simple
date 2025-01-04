using System;
using FluentBuilder.Clip02;
using FluentBuilder.Clip03;
using FluentBuilder.Clip04;
using FluentBuilder.Clip05;

namespace FluentBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            new BuilderDemo.BuilderDemo().Run();
            // new Clip02Demo().Run();
            // new Clip03Demo().Run();
            // new Clip04Demo().Run();
            // new Clip05Demo().Run();

            Console.WriteLine();
            Console.Write("Press ENTER to continue . . . ");
            Console.ReadLine();
        }
    }
}
