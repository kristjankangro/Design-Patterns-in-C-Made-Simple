using System;
using System.Linq;

namespace BuilderDemo
{
    class BuilderDemo : Demo.Common.Demo
    {
        private string Escape(string s) => ";' \t".ToCharArray().Any(s.Contains) ? $"\"{s.Replace("\"","\"\"")}\""
            : s.Contains("\"") ? $"'{s}'"
            : s;
        
        private string CreateConnectionString(string dataSource, int port, string catalog, string username, string password, bool security) =>
            $"Data Source={Escape(port >= 0 ? $"{dataSource},{port}" : dataSource)};" +
            $"Initial Catalog={Escape(catalog)};" +
            (security ? $"; Integrated Security=true" : $"User Id={Escape(username)};" + $"Password={Escape(password)}");

        protected override void Implementation()
        {
            //problems many arguments, semicolon in any param can lead to security issue, injection
            var connString = CreateConnectionString("localhost", 1433, "DemoDB", "my", "na;Initial Catalog=Bank", true);

            Console.WriteLine(connString);
        }
    }
}