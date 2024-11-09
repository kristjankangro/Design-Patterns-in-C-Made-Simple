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
            Use(new CheapDataAccess(), ConnStrFactoryFor("localhost"));
            Use(new FastDataAccess(), ConnStrFactoryFor("BankServer"));
            Use(new FastDataAccess(), pwd => $"Data Source=localhost;Initial Catalog=DemoDB;User Id=my;Password={pwd}");
        }

        private static string CreateConnStr(string server, string password)
        {
            return $"Data Source={server};Initial Catalog=DemoDB;User Id=my;Password={password}";
        }

        private static Func<string, string> ConnStrFactoryFor(string server)
        {
            return password => CreateConnStr(server, password);
        }

        private static string Server = "localhost";
        private static string Database = "DemoDB";
        private static string User = "my";

        private static string LocalConnStr(string password) =>
            $"Data Source={Server};Initial Catalog={Database};User Id={User};Password={password}";

        private static void Use(IDataAccess gateway, Func<string, string> createConnStr)
        {
            string password = "123456";
            var connStr = createConnStr(password);
            // var connStr = @"Data Source=localhost;Initial Catalog=DemoDB;User Id=my;Password=name";
            new HeadHunter(connStr, gateway).AddEmployee("Kristjan");
            Console.WriteLine();
        }
    }
}