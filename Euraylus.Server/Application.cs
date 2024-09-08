using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euraylus.Server.Sockets;
using Fleck;
using Microsoft.Extensions.Logging;

namespace Euraylus.Server;
public class Application : IApplication {
    private readonly ILogger<Application> logger;
    private readonly ISocketEventHandler socket_event_handler;

    private readonly IWebSocketServer server;

    public Application( ILogger<Application> logger,
                        ISocketEventHandler socket_event_handler ) {
        this.logger = logger;
        this.socket_event_handler = socket_event_handler;

        // configure ws server
        string location = "ws://0.0.0.0:1232"; // todo: change this...
        this.server = new WebSocketServer( location );

        FleckLog.Level = Fleck.LogLevel.Error;
        FleckLog.LogAction = ( level, message, ex ) => {
            switch( level ) {
                case Fleck.LogLevel.Error:
                    this.logger.LogError( $"Fleck Error: {message} // {ex.ToString()}" );
                    break;
            }
        };
    }

    public void Run() {
        this.server.Start( socket => {
            socket.OnOpen = () => this.socket_event_handler.OnOpen( socket );
            socket.OnClose = () => this.socket_event_handler.OnClose( socket );
            socket.OnMessage = ( message ) => this.socket_event_handler.OnMessage( socket, message );
            socket.OnBinary = ( buffer ) => this.socket_event_handler.OnBinary( socket, buffer );
            socket.OnError = ( ex ) => this.socket_event_handler.OnError( socket, ex );
        } );

        while( true ) { }
    }
}
