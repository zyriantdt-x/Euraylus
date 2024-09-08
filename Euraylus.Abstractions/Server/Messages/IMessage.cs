using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages;
public interface IMessage {
    string Header { get; init; }
    Dictionary<string, object> Body { get; init; }

    public void WriteObject( string key, object value );
    public object? ReadObject( string key );
}
