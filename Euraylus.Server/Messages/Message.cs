using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages;
public class Message : IMessage {
    [JsonProperty("header")] public required string Header { get; init; }
    [JsonProperty("body")] public required Dictionary<string, object> Body { get; init; }

    public object? ReadObject( string key )
        => this.Body.Where( kvp => kvp.Key == key ).FirstOrDefault().Value;

    public void WriteObject( string key, object value )
        => this.Body.Add( key, value );

    public override string ToString()
        => JsonConvert.SerializeObject( this );
}
