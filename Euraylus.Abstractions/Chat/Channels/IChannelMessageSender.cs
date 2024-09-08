using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels;
public interface IChannelMessageSender {
    void SendMessage( IChannelMessage message );
}
