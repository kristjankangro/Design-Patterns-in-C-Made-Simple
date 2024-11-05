using System;
using AbstractFactory.CheapDb;
using AbstractFactory.Data;
using AbstractFactory.FastDb;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = @"Data Source=localhost;Initial Catalog=DemoDB;User Id=my;Password=name";
            
            //supports only localhost and fails 
            var connStrFailur = @"Data Source=SomeotherServer;Initial Catalog=DemoDB;User Id=my;Password=name";
            
            
            IDataAccess gateway = new FastDataAccess();

            new HeadHunter(connStr, gateway).AddEmployee("Kristjan");

            IDataAccess db = new CheapDataAccess();
            
            new HeadHunter(connStr, db).AddEmployee("Kristjan");
            
            Console.WriteLine();
            Console.Write("Press ENTER to continue . . . ");
            Console.ReadLine();
        }
    }
}