using System;

namespace FluentBuilder.Clip02
{
    class Clip02Demo : Common.Demo
    {
        protected override void Implementation()
        {
            try
            {
                Console.WriteLine(
                    ConnectionStringBuilder.WithCredentials("DemoDB", "localhost", "my", "name")
                        .WithTimeout(11)
                        .Build()
                );
                Console.WriteLine(
                    ConnectionStringBuilder.UsingIntegratedSecurity("DemoDB", "localhost", 1435)
                        .WithProvider("System.Data.SqlClient")
                        .Build()
                );

                Console.WriteLine(
                    ConnectionStringBuilder.UsingIntegratedSecurity("DemoDB", "localhost", 1435).Build()
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}