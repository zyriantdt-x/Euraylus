using Euraylus.Server.Messages.Composers.Handshake;
using Euraylus.Server.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages.Handlers.Handshake;
public class PingMessageHandler : IMessageHandler {
    public string Header => "PING";

    private readonly IMessageSender message_sender;

    public PingMessageHandler( IMessageSender message_sender ) {
        this.message_sender = message_sender;
    }

    public void Handle( ISession session, IMessage message ) {
        HelloMessageComposer pong = new();

        this.message_sender.SendMessage( session, pong );
    }
}
