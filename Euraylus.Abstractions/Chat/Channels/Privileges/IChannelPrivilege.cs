using Euraylus.Users;
using Euraylus.Users.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels.Privileges;
public interface IChannelPrivilege {
    IChannel Channel { get; init; }
    IUser User { get; init; }
    UserRank PrivilegeLevel { get; set; }
}
