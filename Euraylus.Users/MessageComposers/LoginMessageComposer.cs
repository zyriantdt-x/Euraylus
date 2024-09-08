using Euraylus.Server.Messages;
using Euraylus.Server.Messages.Composers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Users.MessageComposers;
internal class LoginMessageComposer : AbstractMessageComposer {
    public override string Header => "LOGIN";

    public required IUser User { get; set; }

    public override void Compose( IMessage message_structure ) {
        message_structure.WriteObject("uuid", this.User.Uuid);
        message_structure.WriteObject( "username", this.User.Username );
    }
}
