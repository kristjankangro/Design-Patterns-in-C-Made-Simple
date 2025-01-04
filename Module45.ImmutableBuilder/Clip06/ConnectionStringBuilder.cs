using System;
using System.Linq;

namespace Demo.Clip06
{
    class ConnectionStringBuilder :
        IExpectsInitialCatalog, IExpectsAuthentication, IOptionalsBuilder
    {
        private string DataSource { get; set; }
        private string InitialCatalog { get; set; }
        private string Security { get; set; }
        private string ConnectTimeoutSegment { get; set; } = string.Empty;
        private string ProviderSegment { get; set; }

        public ConnectionStringBuilder(string dataSource, string initialCatalog, string security, string connectTimeoutSegment, string providerSegment)
        {
            DataSource = dataSource;
            InitialCatalog = initialCatalog;
            Security = security;
            ConnectTimeoutSegment = connectTimeoutSegment;
            ProviderSegment = providerSegment;
        }

        public static IExpectsInitialCatalog WithDataSource(string dataSource) =>
            new ConnectionStringBuilder(ValidDataSource(dataSource), null, null, string.Empty, null);

        public static IExpectsInitialCatalog WithDataSource(string dataSource, int port) =>
            new ConnectionStringBuilder($"{ValidDataSource(dataSource)},{port}", null, null, string.Empty, null);

        private static string ValidDataSource(string dataSource) =>
            string.IsNullOrWhiteSpace(dataSource)
                ? throw new ArgumentException(nameof(dataSource))
                : dataSource;

        public IExpectsAuthentication WithInitialCatalog(string initialCatalog) =>
            new ConnectionStringBuilder(DataSource, ValidInitialCatalog(initialCatalog), null, string.Empty, null);

        private static string ValidInitialCatalog(string initialCatalog) =>
            string.IsNullOrWhiteSpace(initialCatalog)
                ? throw new ArgumentException(nameof(initialCatalog))
                : initialCatalog;

        public IOptionalsBuilder WithCredentials(string userId, string password) =>
            new ConnectionStringBuilder(DataSource, InitialCatalog, Credentials(userId, password), string.Empty, null);

        private static string Credentials(string user, string password) =>
            !string.IsNullOrWhiteSpace(user) && !(password is null)
                ? $"User Id={Escape(user)};Password={Escape(password)}"
                : throw new ArgumentException();

        public IOptionalsBuilder UsingIntegratedSecurity() =>
            new ConnectionStringBuilder(DataSource, InitialCatalog, "Integrated Security=true", string.Empty, null);

        public IOptionalsBuilder UsingTrustedConnection() =>
            new ConnectionStringBuilder(DataSource, InitialCatalog, "Trusted Connection=yes", string.Empty, null);

        public IOptionalsBuilder WithConnectTimeout(int seconds) =>
            new ConnectionStringBuilder(DataSource, InitialCatalog, Security, $";Connect Timeout={seconds}", ProviderSegment);

        public IOptionalsBuilder WithProvider(string name) =>
            new ConnectionStringBuilder(DataSource, InitialCatalog, Security, ConnectTimeoutSegment,
                ProviderSegment ?? $"Provider={Escape(ValidProvider(name))};");

        private string ValidProvider(string name) =>
            !string.IsNullOrEmpty(name)
                ? name
                : throw new ArgumentException(nameof(name));

        public string Build() =>
            $"{this.ProviderSegment}Data Source={Escape(this.DataSource)};" +
            $"Initial Catalog={Escape(this.InitialCatalog)};" +
            $"{this.Security}{this.ConnectTimeoutSegment}";

        private static string Escape(string value) =>
            ";' \t".ToCharArray().Any(ch => value?.Contains(ch) ?? false) ? $"\"{value?.Replace("\"", "\"\"")}\""
            : value?.Contains("\"") ?? false ? $"'{value}'"
            : value;
    }
}