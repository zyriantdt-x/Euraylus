using Euraylus.Chat.ChatUsers;
using Euraylus.Chat.Composers;
using Euraylus.Server.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels;
internal class ChannelMessageSender : IChannelMessageSender {
    private readonly IMessageSender message_sender;

    public ChannelMessageSender( IMessageSender message_sender ) {
        this.message_sender = message_sender;
    }

    public void SendMessage( IChannelMessage message ) {
        ChannelMessageMessageComposer composer = new() {
            ChannelMessage = message
        };

        foreach( IChatUser chat_user in message.Channel.ChatUsers )
            this.message_sender.SendMessage( chat_user.User.Session!, composer );
    }
}
