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
internal class ChannelUserListMessageComposer : AbstractMessageComposer {
    public override string Header => "CHANNEL_USER_LIST";

    public required List<IChatUser> ChatUsers { get; set; }

    public override void Compose( IMessage message_structure ) {
        message_structure.WriteObject( "channel_users", this.ChatUsers.Select( user => new {
            uuid = user.User!.Uuid,
            display_name = user.User!.Username,
            colour = user.User.Rank switch {
                UserRank.ADMINISTRATOR => "#D22B2B",
                UserRank.SUPERVISOR => "#FFFF00",
                _ => ""
            }
        } ).ToList()
        );
    }
}
