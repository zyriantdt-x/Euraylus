using Fleck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Sockets;
public interface ISocketEventHandler {
    public void OnOpen( IWebSocketConnection socket );
    public void OnClose( IWebSocketConnection socket );
    public void OnMessage( IWebSocketConnection socket, string message );
    public void OnBinary( IWebSocketConnection socket, byte[] buffer );
    public void OnError( IWebSocketConnection socket, Exception ex );
}
