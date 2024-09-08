using Euraylus.Chat.ChatUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels;
internal class ChannelMessage : IChannelMessage {
    public required string Uuid { get; init; }
    
    public required IChatUser Sender { get; init; }
    public required IChannel Channel { get; init; }
    public required DateTime Timestamp { get; init; }

    public required string Message { get; init; }
}
