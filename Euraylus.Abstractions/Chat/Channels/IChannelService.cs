using Euraylus.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels;
public interface IChannelService {
    void SendAvailableChannels( IUser user );
    void JoinChannel( string channel_uuid, IUser user );
    void JoinChannel( IChannel channel, IUser user );
    void LeaveChannel( IUser user );
}
