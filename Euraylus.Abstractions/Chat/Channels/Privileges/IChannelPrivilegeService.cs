using Euraylus.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels.Privileges;
public interface IChannelPrivilegeService {
    List<IChannelPrivilege> GetChannelPrivilegesByUser( IUser user );
    List<IChannelPrivilege> GetChannelPrivilegesByChannel( IChannel channel );
    IChannelPrivilege? GetChannelPrivilege( IChannel channel, IUser user );
}
