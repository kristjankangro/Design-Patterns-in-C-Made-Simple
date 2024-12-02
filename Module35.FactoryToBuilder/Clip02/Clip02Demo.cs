using System;

namespace Demo.Clip02
{
    class Clip02Demo : Common.Demo
    {
        private ConnectionStringBuilder FillCredentials(ConnectionStringBuilder partialbuilder) =>
            partialbuilder.WithCredentials("my", "name");

        private void DoStuff(Func<string> doStuff)
        {
            var cs = doStuff();
        }
        
        private void DoStuff(Func<string, string, string> doStuff)
        {
            var cs = doStuff("my", "name");
        }

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

                Console.WriteLine(
                    new ConnectionStringBuilder()
                        .WithDataSource("localhost", 1435)
                        .WithInitialCatalog("DemoDB")
                        .UseIntegratedSecurity()
                        .Build()
                );
                DoStuff(new ConnectionStringBuilder()
                    .WithDataSource("localhost", 1435)
                    .WithInitialCatalog("DemoDB")
                    .UseIntegratedSecurity()
                    .AsFactory());

                DoStuff((userId, password) => new ConnectionStringBuilder()
                    .WithDataSource("localhost")
                    .WithInitialCatalog("DemoDB")
                    .WithCredentials(userId, password).Build());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}