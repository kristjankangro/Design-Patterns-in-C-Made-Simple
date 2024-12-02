using System;
using System.Linq;

namespace Demo.Clip02
{
    public class ConnectionStringBuilder
    {
        private string DataSource { get; set; }
        private int Port { get; set; } = 1433;
        private string InitialCatalog { get; set; }
        private bool IntegratedSecurity { get; set; }
        private string UserId { get; set; }
        private string Password { get; set; }

        public ConnectionStringBuilder WithDataSource(string dataSource)
        {
            DataSource = dataSource;
            return this;
        }

        public ConnectionStringBuilder WithInitialCatalog(string catalog)
        {
            InitialCatalog = catalog;
            return this;
        }
        public ConnectionStringBuilder WithCredentials(string userId, string password)
        {
            UserId = userId;
            Password = password;
            return this;
        }

        public string Build() => 
            $"Data Source={this.Escape(Port < 0 ? DataSource : $"{DataSource},{Port}")};" +
            $"Initial Catalog={this.Escape(InitialCatalog)};" +
            (IntegratedSecurity 
                ? "Integrated Security=true"
                : $"User Id={this.Escape(UserId)};Password={this.Escape(Password)}");
        
        private string Escape(string value) =>
            ";' \t".Any(value.Contains) ? $"\"{value.Replace("\"", "\"\"")}\""
            : value.Contains("\"") ? $"'{value}'"
            : value;
    }
}