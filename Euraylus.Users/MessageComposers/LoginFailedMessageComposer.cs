using Euraylus.Server.Messages;
using Euraylus.Server.Messages.Composers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Users.MessageComposers;
internal class LoginFailedMessageComposer : AbstractMessageComposer {
    public override string Header => "LOGIN_FAILED";

    public required string Reason { get; set; }

    public override void Compose( IMessage message_structure ) {
        message_structure.WriteObject( "reason", this.Reason );
    }
}
