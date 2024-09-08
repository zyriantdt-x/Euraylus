using Euraylus.Server.Messages;
using Euraylus.Server.Messages.Composers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Users.MessageComposers;
internal class LogoutMessageComposer : AbstractMessageComposer {
    public override string Header => "LOGOUT";

    public override void Compose( IMessage message_structure ) {

    }
}
