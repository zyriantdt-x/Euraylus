using Euraylus.Chat.Channels;
using Euraylus.Chat.ChatUsers;
using Euraylus.Server.Messages;
using Euraylus.Server.Messages.Composers;
using Euraylus.Users.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Composers;
public class ChannelJoinedMessageComposer : AbstractMessageComposer {
    public override string Header => "CHANNEL_JOINED";

    public required IChannel Channel { get; set; }
    public required IChatUser ChatUser { get; set; }

    public override void Compose( IMessage message_structure ) {
        message_structure.WriteObject( "uuid", this.Channel.Uuid );
        message_structure.WriteObject( "name", this.Channel.Name );
        message_structure.WriteObject( "privilege_level", this.ChatUser.PrivilegeLevel );
    }
}
