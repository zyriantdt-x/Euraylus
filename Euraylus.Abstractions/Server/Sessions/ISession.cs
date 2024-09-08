using Euraylus.Users;
using Fleck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Sessions;
public interface ISession {
    string Uuid { get; }

    IWebSocketConnection Socket { get; init; }

    IUser? User { get; set; }

    bool IsAuthenticated { get; }
}
