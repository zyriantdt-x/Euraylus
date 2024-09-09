using Euraylus.Chat.Channels;
using Euraylus.Chat.ChatUsers;
using Euraylus.Server.Messages;
using Euraylus.Server.Sessions;
using Euraylus.Users.MessageComposers;
using Euraylus.Users.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Users;
internal class AuthenticationService : IAuthenticationService {
    private readonly IUserService user_service;
    private readonly IChannelJoiner channel_joiner;
    private readonly IMessageSender message_sender;

    public AuthenticationService(IUserService user_service,
                                 IChannelJoiner channel_joiner,
                                 IMessageSender message_sender ) {
        this.user_service = user_service;
        this.channel_joiner = channel_joiner;
        this.message_sender = message_sender;
    }

    public void Login( ISession session, ILoginCredentials credentials ) {
        if( session.IsAuthenticated )
            return;

        IUser? user = this.user_service.GetUserByLogin( credentials.Username, credentials.Password );
        if( user == null ) {
            LoginFailedMessageComposer failed_composer = new() { Reason = "USER_NOT_FOUND" };
            this.message_sender.SendMessage( session, failed_composer );

            return;
        }

        if( user.IsOnline )
            this.Logout( user );

        user.Session = session;
        session.User = user;

        this.user_service.RegisterActiveUser( user );

        LoginMessageComposer login_composer = new() { User = user };
        this.message_sender.SendMessage( session, login_composer );
    }

    public void Logout( IUser user ) {
        if( !user.IsOnline )
            throw new Exception( "Attempt to logout non-authenticated session" );

        LogoutMessageComposer logout_composer = new();
        this.message_sender.SendMessage( user.Session!, logout_composer );

        this.channel_joiner.LeaveChannel( user );

        user.Session!.User = null;
        user.Session = null;

        this.user_service.DeregisterActiveUser( user );
    }
}
