using Euraylus.Chat.Channels;
using Euraylus.Chat.ChatUsers;
using Euraylus.Server.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages.Handlers.Chat;
internal class JoinChannelMessageHandler : IMessageHandler {
    public string Header => "JOIN_CHANNEL";

    private readonly IChannelJoiner channel_joiner;

    public JoinChannelMessageHandler( IChannelJoiner channel_joiner ) {
        this.channel_joiner = channel_joiner;
    }

    public void Handle( ISession session, IMessage message ) {
        string? channel_uuid = Convert.ToString( message.ReadObject( "channel" ) );
        if( channel_uuid == null )
            return;

        this.channel_joiner.JoinChannel( channel_uuid, session.User );
    }
}
