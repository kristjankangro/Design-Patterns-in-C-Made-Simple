using System;
using System.Text.RegularExpressions;
using Demo.Clip01.Data;

namespace Demo.Clip01.CheapDb
{
    public class CheapDataAccess : IDataAccess
    {
        public IConnection CreateConnection(string connectionString) =>
            IsLocalhost(connectionString)
                ? new Connection(
                    DataBase(connectionString),
                    UserName(connectionString),
                    Password(connectionString))
                : throw new ArgumentException("Invalid connection string");

        private bool IsLocalhost(string connectionString) =>
            ValueOf(connectionString, "Data Source", "localhost") == "localhost";

        private string DataBase(string connectionString) => ValueOf(connectionString, "DataBase");
        private string UserName(string connectionString) => ValueOf(connectionString, "User Id");
        private string Password(string connectionString) => ValueOf(connectionString, "Password");

        private string ValueOf(string connectionString, string key, string substitution) =>
            Regex.Match(connectionString, $"{key}=(?<value[^;]+>);")
                is { Success: true } pair
                ? pair.Groups["value"].Value
                : substitution;

        private string ValueOf(string connectionString, string key) =>
            ValueOf(connectionString, key, string.Empty);

        public ICommand CreateCommand(string commandText)
        {
            throw new System.NotImplementedException();
        }

        public ITransaction CreateTransaction(IConnection connection)
        {
            throw new System.NotImplementedException();
        }
    }
}