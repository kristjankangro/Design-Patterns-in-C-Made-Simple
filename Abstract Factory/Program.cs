﻿using System;
using AbstractFactory.Data;
using AbstractFactory.FastDb;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = @"Data Source=localhost;Initial Catalog=DemoDB;User Id=my;Password=name";
            IDataAccess gateway = new FastDataAccess();

            new HeadHunter(connStr, gateway).AddEmployee("Kristjan");


            Console.WriteLine();
            Console.Write("Press ENTER to continue . . . ");
            Console.ReadLine();
        }
    }
}