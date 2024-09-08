using Euraylus.Chat.ChatUsers;
using Euraylus.Server.Sessions;
using Euraylus.Users.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Users;
public interface IUser {
    string Uuid { get; init; }
    string Username { get; set; }

    UserRank Rank { get; set; }

    ISession? Session { get; set; }
    IChatUser? ChatUser { get; set; }

    bool IsOnline { get; }
}
