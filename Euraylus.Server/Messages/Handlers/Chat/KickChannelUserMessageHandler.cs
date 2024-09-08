using Euraylus.Chat.Channels;
using Euraylus.Server.Sessions;
using Euraylus.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages.Handlers.Chat;
internal class KickChannelUserMessageHandler : IMessageHandler {
    public string Header => "KICK_CHANNEL_USER";

    private readonly IChannelService channel_service;
    private readonly IUserService user_service;

    public KickChannelUserMessageHandler( IChannelService channel_service,
                                          IUserService user_service ) {
        this.channel_service = channel_service;
        this.user_service = user_service;
    }

    public void Handle( ISession session, IMessage message ) {
        string? user_uuid = Convert.ToString( message.ReadObject( "uuid" ) );
        if( user_uuid == null )
            return;

        if( (int)session.User!.ChatUser!.PrivilegeLevel < 2 )
            return;

        IUser? user = this.user_service.GetUserByUuid( user_uuid );
        if( user == null )
            return;
        if( user.ChatUser == null )
            return;

        this.channel_service.LeaveChannel( user );
    }
}
