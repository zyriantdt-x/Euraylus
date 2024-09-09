using Euraylus.Users.Util;
using Euraylus.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels.Privileges;
public class ChannelPrivilege : IChannelPrivilege {
    public required IChannel Channel { get; init; }
    public required IUser User { get; init; }
    public required UserRank PrivilegeLevel { get; set; }
}
