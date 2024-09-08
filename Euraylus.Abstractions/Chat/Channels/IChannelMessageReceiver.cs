using Euraylus.Chat.ChatUsers;
using Euraylus.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels;
public interface IChannelMessageReceiver {
    void ReceiveMessage( IUser user, string message );
    void ReceiveMessage( IChannelMessage message );
}
