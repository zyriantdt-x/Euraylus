using Euraylus.Server.Messages.Composers;
using Euraylus.Server.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages;
public interface IMessageSender {
    void SendMessage( ISession session, AbstractMessageComposer message_composer );
    void SendMessage( ISession session, IMessage message );
    void SendMessage( ISession session, string message );
}
