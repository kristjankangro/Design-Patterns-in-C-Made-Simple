using System;

namespace Demo.Clip02
{
    class Clip02Demo : Common.Demo
    {
        protected override void Implementation()
        {
            try
            {
                string connStr = new ConnectionStringBuilder()
                    .WithDataSource("localhost")
                    .WithInitialCatalog("DemoDB")
                    .WithCredentials("my", "name")
                    .Build();

                Console.WriteLine(connStr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}