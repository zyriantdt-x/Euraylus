using Euraylus.Chat.Channels;
using Euraylus.Server.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages.Handlers.Chat;
internal class JoinChannelMessageHandler : IMessageHandler {
    public string Header => "JOIN_CHANNEL";

    private readonly IChannelService channel_service;

    public JoinChannelMessageHandler( IChannelService channel_service ) {
        this.channel_service = channel_service;
    }

    public void Handle( ISession session, IMessage message ) {
        string? channel_uuid = Convert.ToString( message.ReadObject( "channel" ) );
        if( channel_uuid == null )
            return;

        this.channel_service.JoinChannel( channel_uuid, session.User );
    }
}
