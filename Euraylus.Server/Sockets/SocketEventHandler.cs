using Euraylus.Server.Messages;
using Euraylus.Server.Messages.Composers.Handshake;
using Euraylus.Server.Sessions;
using Fleck;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Sockets;
public class SocketEventHandler : ISocketEventHandler {
    private readonly ILogger<SocketEventHandler> logger;
    private readonly ISessionService session_service;
    private readonly IMessageReceiver message_receiver;
    private readonly IMessageSender message_sender;

    public SocketEventHandler( ILogger<SocketEventHandler> logger,
                               ISessionService session_service,
                               IMessageReceiver message_receiver,
                               IMessageSender message_sender ) {
        this.logger = logger;
        this.session_service = session_service;
        this.message_receiver = message_receiver;
        this.message_sender = message_sender;
    }

    public void OnOpen( IWebSocketConnection socket ) {
        ISession session = this.session_service.CreateSession( socket );

        this.logger.LogInformation( $"Socket opened -> {socket.ConnectionInfo.ClientIpAddress} / <temp_username>" );

        HelloMessageComposer composer = new();
        this.message_sender.SendMessage( session, composer );
    }

    public void OnClose( IWebSocketConnection socket ) {
        ISession? session = this.session_service.GetSessionBySocket( socket );
        if(session == null) {
            this.logger.LogWarning( $"Attempt to close unregistered socket -> {socket.ConnectionInfo.ClientIpAddress}" );
            return;
        }

        // maybe tell some other services that we're closing

        this.session_service.CloseSession( session );

        this.logger.LogInformation( $"Socket closed -> {socket.ConnectionInfo.ClientIpAddress} / <temp_username>" );
    }

    public void OnMessage( IWebSocketConnection socket, string message ) {
        ISession? session = this.session_service.GetSessionBySocket( socket );
        if( session == null ) {
            this.logger.LogWarning( $"Attempt to handle message from unregistered socket -> {socket.ConnectionInfo.ClientIpAddress}" );
            return;
        }

        this.logger.LogInformation( $"Message received from {socket.ConnectionInfo.ClientIpAddress} / <username> -> {message}" );

        this.message_receiver.ReceiveMessage( session, message );
    }

    // todo
    public void OnBinary( IWebSocketConnection socket, byte[] buffer ) => throw new NotImplementedException();
    public void OnError( IWebSocketConnection socket, Exception ex ) => throw new NotImplementedException();
}
