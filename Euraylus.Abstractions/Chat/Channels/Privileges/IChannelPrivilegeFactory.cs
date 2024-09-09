using Euraylus.Storage.Sets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels.Privileges;
public interface IChannelPrivilegeFactory {
    IChannelPrivilege CreateChannelPrivilege( IChannelPrivilegesSet set );
}
