using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Demo.Clip02
{
    public class ConnectionStringBuilder
    {
        private string DataSource { get; set; }
        private int Port { get; set; } = 1433;
        private string InitialCatalog { get; set; }

        private string Security { get; set; }
        private bool IsSecurityValid { get; set; }

        private string TimeoutSegment { get; set; } = string.Empty;
        private string ProviderSegment { get; set; } = string.Empty;

        public ConnectionStringBuilder WithDataSource(string dataSource)
        {
            DataSource = dataSource;
            return this;
        }

        public ConnectionStringBuilder WithTimeout(int seconds)
        {
            TimeoutSegment = $"; Connect Timeout={seconds}";
            return this;
        }

        public ConnectionStringBuilder WithProvider(string name)
        {
            ProviderSegment ??= $"Provider={Escape(name)};";
            return this;
        }

        public ConnectionStringBuilder WithDataSource(string dataSource, int port)
        {
            DataSource = $"{dataSource},{port}";
            return this;
        }

        public ConnectionStringBuilder WithInitialCatalog(string catalog)
        {
            InitialCatalog = catalog;
            return this;
        }

        public ConnectionStringBuilder WithCredentials(string userId, string password)
        {
            IsSecurityValid = !string.IsNullOrWhiteSpace(userId) && password is not null;
            Security = $"User Id={this.Escape(userId)};Password={this.Escape(password)}";
            return this;
        }

        public ConnectionStringBuilder UseIntegratedSecurity()
        {
            IsSecurityValid = true;
            Security = "Integrated Security=true";
            return this;
        }

        public ConnectionStringBuilder UseTrustedConnection()
        {
            IsSecurityValid = true;
            Security = "Trusted Connection=yes";
            return this;
        }

        public bool CanBuild() =>
            !string.IsNullOrEmpty(DataSource) &&
            !string.IsNullOrEmpty(InitialCatalog) &&
            IsSecurityValid;

        public string Build() =>
            CanBuild() ? SafeBuild() : throw new InvalidOperationException("Can't build connection string");

        public Func<string> AsFactory() => CanBuild()
            ? (Func<string>)SafeBuild
            : throw new InvalidOperationException("Can't build connection string");

        public string SafeBuild() =>
            ProviderSegment +
            $"Data Source={this.Escape(Port < 0 ? DataSource : $"{DataSource},{Port}")};" +
            $"Initial Catalog={this.Escape(InitialCatalog)};" +
            Security +
            TimeoutSegment;

        private string Escape(string value) =>
            ";' \t".Any(value.Contains) ? $"\"{value.Replace("\"", "\"\"")}\""
            : value.Contains("\"") ? $"'{value}'"
            : value;
    }
}