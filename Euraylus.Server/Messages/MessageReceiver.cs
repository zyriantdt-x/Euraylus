using Euraylus.Server.Messages.Handlers;
using Euraylus.Server.Sessions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages;
public class MessageReceiver : IMessageReceiver {
    private readonly ILogger<MessageReceiver> logger;
    private readonly IMessageFactory factory;
    private readonly List<IMessageHandler> handlers;

    public MessageReceiver( ILogger<MessageReceiver> logger,
                           IMessageFactory factory,
                           IEnumerable<IMessageHandler> handlers ) {
        this.logger = logger;
        this.factory = factory;
        this.handlers = handlers.ToList();
    }

    public void ReceiveMessage( ISession session, string message ) {
        IMessage? message_obj = this.factory.CreateMessageFromJson( message );
        if(message_obj == null) {
            this.logger.LogWarning( $"Unable to parse message into Message -> {message}" );
            return;
        }

        if( message_obj.Header == null ) {
            this.logger.LogWarning( $"Unable to parse message into Message -> {message}" );
            return;
        }

        this.ReceiveMessage( session, message_obj );
    }

    public void ReceiveMessage( ISession session, IMessage message ) {
        string display_name = session.IsAuthenticated ? session.User!.Username : session.Socket.ConnectionInfo.ClientIpAddress;
        this.logger.LogInformation( $"Message from {display_name} received: {message}" );

        IMessageHandler? handler = this.GetMessageHandler( message.Header );
        if( handler == null ) {
            this.logger.LogWarning( $"Unable to get handler -> {message.Header}" );
            return;
        }

        handler.Handle( session, message );
    }

    public IMessageHandler? GetMessageHandler( string header )
        => this.handlers.Where( handler => handler.Header == header.ToUpper() ).FirstOrDefault();
}
