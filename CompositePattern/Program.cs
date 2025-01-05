using System;
using CompositePattern.Module48;
using CompositePattern.Module49;
using CompositePattern.Module50;
using Demo.Clip03;
using Demo.Clip04;
using Demo.Clip05;
using Demo.Clip06;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // new Clip01Demo().Run();
            // new Module49.Module49().Run();
            new Clip03Demo().Run();
            // new Clip04Demo().Run();
            // new Clip05Demo().Run();
            // new Clip06Demo().Run();

            Console.WriteLine();
            Console.Write("Press ENTER to continue . . . ");
            Console.ReadLine();
        }
    }
}
