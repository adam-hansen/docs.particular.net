using System;
using NServiceBus;
using NServiceBus.Persistence;

class Program
{

    static void Main()
    {
        #region bridge-config

        BusConfiguration busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("SqlBridge");
        busConfiguration.EnableInstallers();
        busConfiguration.UsePersistence<NHibernatePersistence>()
            .ConnectionString(@"Data Source=.\SQLEXPRESS;Initial Catalog=PersistenceForSqlTransport;Integrated Security=True");
        busConfiguration.UseTransport<SqlServerTransport>()
            .ConnectionString(@"Data Source=.\SQLEXPRESS;Initial Catalog=NServiceBus;Integrated Security=True");

        #endregion
        using (IStartableBus bus = Bus.Create(busConfiguration))
        {
            bus.Start();
            Console.WriteLine("\r\nPress any key to stop program\r\n");
            Console.ReadKey();
        }

    }
}