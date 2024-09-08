using Euraylus.Chat.Channels;
using Euraylus.Server.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages.Handlers.Chat;
internal class ChatMessageMessageHandler : IMessageHandler {
    public string Header => "CHAT_MESSAGE";

    private readonly IChannelMessageReceiver channel_message_receiver;

    public ChatMessageMessageHandler( IChannelMessageReceiver channel_message_receiver ) {
        this.channel_message_receiver = channel_message_receiver;
    }

    public void Handle( ISession session, IMessage message ) {
        if( !session.IsAuthenticated )
            return;
        if( session.User!.ChatUser == null )
            return;

        string? message_str = Convert.ToString( message.ReadObject( "message" ) );
        if( message_str == null )
            return;

        this.channel_message_receiver.ReceiveMessage( session.User!, message_str );
    }
}
