using Euraylus.Users;
using Fleck;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Sessions;
public class SessionService : ISessionService {
    private readonly ILogger<SessionService> logger;
    private readonly IAuthenticationService auth_service;

    private readonly List<ISession> active_sessions;

    public SessionService( ILogger<SessionService> logger,
                           IAuthenticationService auth_service ) {
        this.logger = logger;
        this.auth_service = auth_service;

        this.active_sessions = new();
    }

    public ISession CreateSession( IWebSocketConnection socket ) {
        ISession session = new Session() {
            Uuid = Guid.NewGuid().ToString(),
            Socket = socket
        };

        this.active_sessions.Add( session );

        return session;
    }

    public void CloseSession( ISession session ) {
        if( session.Socket.IsAvailable )
            session.Socket.Close();

        if( !this.active_sessions.Remove( session ) )
            this.logger.LogWarning( "Unable to remove Session instance from ActiveSessions -- it does not exist." );

        if( session.IsAuthenticated )
            this.auth_service.Logout( session.User! );
    }

    public ISession? GetSessionByUuid( string uuid )
        => this.active_sessions.Where( session => session.Uuid == uuid ).FirstOrDefault();

    public ISession? GetSessionBySocket( IWebSocketConnection socket )
        => this.active_sessions.Where( session => session.Socket == socket ).FirstOrDefault();
}
