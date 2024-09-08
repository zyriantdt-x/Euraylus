using Euraylus.Server.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages.Handlers;
public interface IMessageHandler {
    string Header { get; }

    void Handle( ISession session, IMessage message );
}
