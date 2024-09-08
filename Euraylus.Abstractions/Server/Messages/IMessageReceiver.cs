using Euraylus.Server.Messages.Handlers;
using Euraylus.Server.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages;
public interface IMessageReceiver {
    void ReceiveMessage( ISession session, string message );
    void ReceiveMessage( ISession session, IMessage message );

    IMessageHandler? GetMessageHandler( string header );
}
