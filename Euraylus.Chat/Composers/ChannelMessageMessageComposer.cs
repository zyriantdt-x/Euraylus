using Euraylus.Chat.Channels;
using Euraylus.Server.Messages;
using Euraylus.Server.Messages.Composers;
using Euraylus.Users.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Composers;
internal class ChannelMessageMessageComposer : AbstractMessageComposer {
    public override string Header => "CHANNEL_MESSAGE";

    public required IChannelMessage ChannelMessage { get; set; }

    public override void Compose( IMessage message_structure ) {
        message_structure.WriteObject( "timestamp", this.ChannelMessage.Timestamp );
        message_structure.WriteObject( "sender", new {
            display_name = this.ChannelMessage.Sender.User.Username,
            colour = this.ChannelMessage.Sender.User.Rank switch {
                UserRank.ADMINISTRATOR => "#D22B2B",
                UserRank.SUPERVISOR => "#FFFF00",
                _ => ""
            }
        } );
        message_structure.WriteObject( "message", this.ChannelMessage.Message );
    }
}
