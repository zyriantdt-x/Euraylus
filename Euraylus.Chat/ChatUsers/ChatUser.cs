using Euraylus.Chat.Channels;
using Euraylus.Users;
using Euraylus.Users.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.ChatUsers;
internal class ChatUser : IChatUser {
    public required string Uuid { get; init; }
    public required IUser User { get; init; }
    public required IChannel Channel { get; init; }
    public required UserRank PrivilegeLevel { get; init; }
}
