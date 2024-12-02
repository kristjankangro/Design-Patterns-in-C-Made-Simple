using System;

namespace Demo.Clip02
{
    class Clip02Demo : Common.Demo
    {
        private ConnectionStringBuilder FillCredentials(ConnectionStringBuilder partialbuilder) =>
            partialbuilder.WithCredentials("my", "name");

        protected override void Implementation()
        {
            try
            {
                var builder = new ConnectionStringBuilder()
                    .WithDataSource("localhost")
                    .WithInitialCatalog("DemoDB");

                builder = FillCredentials(builder);
                if (builder.CanBuild()) Console.WriteLine("Safe to build");
                
                var connStr = builder.Build();
                Console.WriteLine(connStr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}