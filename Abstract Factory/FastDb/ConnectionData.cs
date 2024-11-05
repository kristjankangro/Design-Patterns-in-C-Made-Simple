using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractFactory.FastDb
{
    public class ConnectionData
    {
        private IDictionary<string, string> KeyValues { get; }
        
        
        public ConnectionData(string connectionString)
        {
            KeyValues = connectionString.Split(';')
                .Select(pair => (keyValue: pair, separtorPos: pair.IndexOf('=')))
                .ToDictionary(
                    pair => pair.keyValue[..pair.separtorPos],
                    pair => pair.keyValue[(pair.separtorPos + 1)..]
                );
            
            if (!UnsupportedKeys.Any()) throw new ArgumentException("Unsupported connection string");
        }
        
        public string Server => KeyValues.TryGetValue(ServerKey, out string? server) ? server : "localhost";
        public string Database => KeyValues[this.DatabaseKey];
        public Credentials Credentials => new UserCredentials(UserName, Password);
        
        private string UserName => KeyValues[UserNameKey];
        private string Password => KeyValues[PasswordKey];
        private IEnumerable<string> UnsupportedKeys 
            => KeyValues.Keys.Except(new []{this.ServerKey, this.DatabaseKey, this.UserNameKey, });
        
        private readonly string ServerKey = "Data Source";
        private string DatabaseKey = "Initial Catalog";
        private string UserNameKey = "User Id";
        private string PasswordKey = "Password";
    }
}