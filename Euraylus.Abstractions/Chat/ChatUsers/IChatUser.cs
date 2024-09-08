using Euraylus.Chat.Channels;
using Euraylus.Users;
using Euraylus.Users.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.ChatUsers;
public interface IChatUser {
    string Uuid { get; init; }
    IUser User { get; init; }
    IChannel Channel { get; init; }
    UserRank PrivilegeLevel { get; init; }
}
