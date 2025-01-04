using System;
using System.Linq;

namespace FluentBuilder.Clip05
{
    class ConnectionStringBuilder : IExpectsInitialCatalog,
        IExpectAuthentication, IOptionalBuilder
    {
        private string DataSource { get; set; }
        private string InitialCatalog { get; set; }
        private string Security { get; set; }
        private string ConnectTimeoutSegment { get; set; } = string.Empty;
        private string ProviderSegment { get; set; }

        private ConnectionStringBuilder()
        {
        }

        public static IExpectsInitialCatalog WithDataSource(string dataSource) => new ConnectionStringBuilder() { DataSource = ValidDataSource(dataSource) };

        public static IExpectsInitialCatalog WithDataSource(string dataSource, int port) =>
            new ConnectionStringBuilder() { DataSource = $"{ValidDataSource(dataSource)},{port}" };

        private static string ValidDataSource(string dataSource) => string.IsNullOrWhiteSpace(dataSource)
            ? throw new ArgumentException()
            : dataSource;


        private static string Credentials(string user, string password) =>
            !string.IsNullOrWhiteSpace(user) && !(password is null)
                ? $"User Id={Escape(user)};Password={Escape(password)}"
                : throw new ArgumentException();


        public IOptionalBuilder WithTimeout(int seconds)
        {
            this.ConnectTimeoutSegment = $";Connect Timeout={seconds}";
            return this;
        }

        public IOptionalBuilder WithProvider(string name)
        {
            this.ProviderSegment ??= $"Provider={Escape(name)};";
            return this;
        }

        public string Build() =>
            $"{this.ProviderSegment}Data Source={Escape(this.DataSource)};" +
            $"Initial Catalog={Escape(this.InitialCatalog)};" +
            $"{this.Security}{this.ConnectTimeoutSegment}";

        private static string Escape(string value) =>
            ";' \t".ToCharArray().Any(ch => value?.Contains(ch) ?? false) ? $"\"{value?.Replace("\"", "\"\"")}\""
            : value?.Contains("\"") ?? false ? $"'{value}'"
            : value;

        public IExpectAuthentication WithInitialCatalog(string initialCatalog)
        {
            InitialCatalog = ValidInitialCatalog(initialCatalog);
            return this;
        }

        private string ValidInitialCatalog(string initialCatalog)
        {
            return string.IsNullOrWhiteSpace(initialCatalog)
                ? throw new ArgumentNullException(nameof(initialCatalog))
                : initialCatalog;
        }

        public IOptionalBuilder WithCredentials(string username, string password)
        {
            Security = Credentials(username, password);
            return this;
        }

        public IOptionalBuilder UsingIntegratedSecurity()
        {
            Security = "Integrated Security=true";
            return this;
        }

        public IOptionalBuilder UsingTrustedConnection()
        {
            Security = "Trusted Connection=yes";
            return this;
        }
    }
}