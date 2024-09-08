using Euraylus.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels;
internal class ChannelMessageReceiver : IChannelMessageReceiver {
    private readonly IChannelMessageSender sender;

    public ChannelMessageReceiver( IChannelMessageSender sender ) {
        this.sender = sender;
    }

    public void ReceiveMessage( IUser user, string message ) {
        IChannelMessage message_obj = new ChannelMessage() {
            Uuid = Guid.NewGuid().ToString(),
            Sender = user.ChatUser!,
            Channel = user.ChatUser!.Channel,
            Message = message,
            Timestamp = DateTime.Now
        };

        this.ReceiveMessage( message_obj );
    }

    public void ReceiveMessage( IChannelMessage message ) {
        this.sender.SendMessage( message );

        // log 
    }
}
