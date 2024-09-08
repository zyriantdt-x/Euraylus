using Euraylus.Chat.Channels;
using Euraylus.Server.Messages;
using Euraylus.Server.Messages.Composers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Composers;
internal class ChannelListMessageComposer : AbstractMessageComposer {
    public override string Header => "CHANNEL_LIST";

    public required List<IChannel> Channels { get; set; }

    public override void Compose( IMessage message_structure ) {
        message_structure.WriteObject( "channels", this.Channels.Select( channel => new { uuid = channel.Uuid, name = channel.Name } ).ToList() );
    }
}
