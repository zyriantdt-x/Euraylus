using Euraylus.Chat.Channels;
using Euraylus.Server.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages.Handlers.Chat;
internal class GetChannelsMessageHandler : IMessageHandler {
    public string Header => "GET_CHANNELS";

    private readonly IChannelService channel_service;

    public GetChannelsMessageHandler( IChannelService channel_service ) {
        this.channel_service = channel_service;
    }

    public void Handle( ISession session, IMessage message ) {
        this.channel_service.SendAvailableChannels( session.User! );
    }
}
