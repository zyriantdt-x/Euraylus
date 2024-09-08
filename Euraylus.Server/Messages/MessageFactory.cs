using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages;
public class MessageFactory : IMessageFactory {
    public IMessage? CreateMessageFromJson( string json )
        => JsonConvert.DeserializeObject<Message>( json );
    public IMessage CreateEmptyMessage( string header )
        => new Message() { 
            Header = header, 
            Body = new() 
        };
}
