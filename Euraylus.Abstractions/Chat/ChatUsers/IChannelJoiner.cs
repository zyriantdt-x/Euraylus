using Euraylus.Chat.Channels;
using Euraylus.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.ChatUsers;
public interface IChannelJoiner {
    void JoinChannel( string channel_uuid, IUser user );
    void JoinChannel( IChannel channel, IUser user );
    void LeaveChannel( IUser user );

    // not really sure where else to put this
    void SendAvailableChannels( IUser user );
}
