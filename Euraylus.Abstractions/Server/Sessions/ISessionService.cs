using Euraylus.Users;
using Fleck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Sessions;
public interface ISessionService {
    public ISession CreateSession( IWebSocketConnection socket );

    public void CloseSession( ISession session );

    public ISession? GetSessionByUuid( string uuid );
    public ISession? GetSessionBySocket( IWebSocketConnection socket );
}
