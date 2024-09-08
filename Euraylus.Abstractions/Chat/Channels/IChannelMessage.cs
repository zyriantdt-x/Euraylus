using Euraylus.Chat.ChatUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels;
public interface IChannelMessage {
    string Uuid { get; init; }
    
    IChatUser Sender { get; init; }
    IChannel Channel { get; init; }
    DateTime Timestamp { get; init; }

    string Message { get; init; }
}
