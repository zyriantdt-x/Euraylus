using Euraylus.Users;
using Fleck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Sessions;
public class Session : ISession {
    public required string Uuid { get; init; }

    public required IWebSocketConnection Socket { get; init; }
    public IUser? User { get; set; }

    public bool IsAuthenticated => this.User != null;
}
