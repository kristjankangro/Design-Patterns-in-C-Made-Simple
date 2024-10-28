using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip01.FastDb
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
            
            if (UnsupportedKeys.Any()) throw new ArgumentException("Unsupported connection string");
        }
        
        private IEnumerable<string> UnsupportedKeys => KeyValues.Except(this.ServerKey);
        private const string ServerKey = VALUE;
    }
}