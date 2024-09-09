using Euraylus.Chat.Channels;
using Euraylus.Chat.ChatUsers;
using Euraylus.Server.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages.Handlers.Chat;
internal class GetChannelsMessageHandler : IMessageHandler {
    public string Header => "GET_CHANNELS";

    private readonly IChannelJoiner channel_joiner;

    public GetChannelsMessageHandler( IChannelJoiner channel_joiner ) {
        this.channel_joiner = channel_joiner;
    }

    public void Handle( ISession session, IMessage message ) {
        this.channel_joiner.SendAvailableChannels( session.User! );
    }
}
