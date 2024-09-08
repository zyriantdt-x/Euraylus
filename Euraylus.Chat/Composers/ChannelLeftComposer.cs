using Euraylus.Server.Messages;
using Euraylus.Server.Messages.Composers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Composers;
internal class ChannelLeftComposer : AbstractMessageComposer {
    public override string Header => "CHANNEL_LEFT";

    public override void Compose( IMessage message_structure ) {

    }
}
