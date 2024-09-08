using Euraylus.Server.Sessions;
using Euraylus.Users;
using Euraylus.Users.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages.Handlers.Handshake;
internal class TryLoginMessageHandler : IMessageHandler {
    public string Header => "TRY_LOGIN";

    private readonly IAuthenticationService auth_service;

    public TryLoginMessageHandler( IAuthenticationService auth_service ) {
        this.auth_service = auth_service;
    }

    public void Handle( ISession session, IMessage message ) {
        string? username = Convert.ToString( message.ReadObject( "username" ) );
        string? password = Convert.ToString( message.ReadObject( "password" ) );

        if( username == null || password == null )
            return;

        ILoginCredentials credentials = new LoginCredentials() { 
            Username = username.ToLower(),
            Password = password 
        };

        this.auth_service.Login( session, credentials );
    }
}
