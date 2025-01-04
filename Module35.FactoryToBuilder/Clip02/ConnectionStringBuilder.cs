using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Demo.Clip02
{
    public class ConnectionStringBuilder
    {
        public ConnectionStringBuilder(string initialCatalog, string dataSource)
            : this(initialCatalog, dataSource, string.Empty, "System.Data.SqlClient")
        {
        }


        public ConnectionStringBuilder(string initialCatalog, string dataSource, int port)
            : this(initialCatalog, dataSource, $"{port}", string.Empty)
        {
        }

        public static ConnectionStringBuilder WithCredentials(string initialCatalog, string dataSource, string user, string password)
            => new ConnectionStringBuilder(initialCatalog, dataSource, String.Empty, Credentials(user, password));

        public static ConnectionStringBuilder WithCredentials(string initialCatalog, string dataSource, string user, string password, int port)
            => new ConnectionStringBuilder(initialCatalog, dataSource, $",{port}", Credentials(user, password));

        public static ConnectionStringBuilder UsingIntegratedSecurity(string initialCatalog, string dataSource)
            => new ConnectionStringBuilder(initialCatalog, dataSource, String.Empty, "Integrated Security=true");

        public static ConnectionStringBuilder UsingIntegratedSecurity(string initialCatalog, string dataSource, int port)
            => new ConnectionStringBuilder(initialCatalog, dataSource, $",{port}", "Integrated Security=true");

        public static ConnectionStringBuilder UsingTrustedConnection(string initialCatalog, string dataSource)
            => new ConnectionStringBuilder(initialCatalog, dataSource, String.Empty, "Trusted Connection=yes");

        public static ConnectionStringBuilder UsingTrustedConnection(string initialCatalog, string dataSource, int port)
            => new ConnectionStringBuilder(initialCatalog, dataSource, $",{port}", "Trusted Connection=yes");

        private static string Credentials(string user, string password) =>
            string.IsNullOrWhiteSpace(user) || password is null
                ? throw new ArgumentNullException(nameof(user))
                : $"User Id={Escape(user)};Password={Escape(password)}";

        private ConnectionStringBuilder(string initialCatalog, string dataSource, string formattedPort, string security)
        {
            Security = security;
            DataSource = string.IsNullOrWhiteSpace(dataSource)
                ? throw new ArgumentNullException(nameof(dataSource))
                : $"{dataSource}{formattedPort}";
            InitialCatalog = string.IsNullOrWhiteSpace(initialCatalog)
                ? throw new ArgumentNullException(nameof(initialCatalog))
                : initialCatalog;
        }

        private string DataSource { get; }
        private int Port { get; } = 1433;
        private string InitialCatalog { get; }

        private string Security { get; set; }

        private string TimeoutSegment { get; set; } = string.Empty;
        private string ProviderSegment { get; set; } = string.Empty;


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

        public string Build() =>
            ProviderSegment +
            $"Data Source={Escape(Port < 0 ? DataSource : $"{DataSource},{Port}")};" +
            $"Initial Catalog={Escape(InitialCatalog)};" +
            Security +
            TimeoutSegment;

        private static string Escape(string value) =>
            ";' \t".Any(value.Contains) ? $"\"{value.Replace("\"", "\"\"")}\""
            : value.Contains("\"") ? $"'{value}'"
            : value;
    }
}