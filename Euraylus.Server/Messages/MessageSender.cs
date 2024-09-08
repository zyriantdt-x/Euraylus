using Euraylus.Server.Messages.Composers;
using Euraylus.Server.Sessions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages;
public class MessageSender : IMessageSender {
    private readonly ILogger<MessageSender> logger;
    private readonly IMessageFactory message_factory;

    public MessageSender( ILogger<MessageSender> logger,
                          IMessageFactory message_factory ) {
        this.logger = logger;
        this.message_factory = message_factory;
    }

    public void SendMessage( ISession session, AbstractMessageComposer message_composer ) {
        IMessage message = this.message_factory.CreateEmptyMessage( message_composer.Header );

        message_composer.Compose( message );

        this.SendMessage( session, message );
    }

    public void SendMessage( ISession session, IMessage message )
        => this.SendMessage( session, message.ToString()! ); // we know this will never be null

    public void SendMessage( ISession session, string message ) {
        session.Socket.Send( message );

        string display_name = session.IsAuthenticated ? session.User!.Username : session.Socket.ConnectionInfo.ClientIpAddress;
        this.logger.LogInformation( $"Message to {display_name} sent: {message}" );
    }
}
