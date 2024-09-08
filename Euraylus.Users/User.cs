using Euraylus.Chat.ChatUsers;
using Euraylus.Server.Sessions;
using Euraylus.Users.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Users;
internal class User : IUser {
    public required string Uuid { get; init; }
    public required string Username { get; set; }

    public required UserRank Rank { get; set; }

    public ISession? Session { get; set; }
    public IChatUser? ChatUser { get; set; }

    public bool IsOnline => this.Session != null;
}
