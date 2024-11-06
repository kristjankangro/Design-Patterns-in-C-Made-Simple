using System;
using System.Collections.Generic;
using System.Linq;
using AbstractFactory.Data;

namespace AbstractFactory;

public class HeadHunter
{
    public HeadHunter(string connectionString, IDataAccess databaseGateway)
    {
        ConnectionString = connectionString;
        DatabaseGateway = databaseGateway;
    }

    private string ConnectionString { get; }
    private IDataAccess DatabaseGateway { get; }

    public void AddEmployee(string name)
    {
        IConnection connection = DatabaseGateway.CreateConnection(ConnectionString);
        connection.Connect();

        ITransaction transaction = connection.BeginTransaction();
        
        ICommand command = DatabaseGateway.CreateCommand("INSERT INTO employees (name) VALUES (@name)");
        var insert = connection.Execute(command, transaction);

        Console.WriteLine("Inserted employee: {0}", insert);
        
        ICommand command2 = DatabaseGateway.CreateCommand("select name from employees");
        var select = connection.Execute(command2, transaction);
        
        string selectReport = select is IEnumerable<string> nameSequence ? string.Join(", ", nameSequence.ToArray()) : "";

        Console.WriteLine("Report of employee: {0}", selectReport);
        
        transaction.Commit();
        connection.Disconnect(); //should be put into finally block of try catch
    }
}