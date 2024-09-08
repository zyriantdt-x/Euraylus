using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages;
public interface IMessageFactory {
    IMessage? CreateMessageFromJson( string json );
    IMessage CreateEmptyMessage( string header );
}
