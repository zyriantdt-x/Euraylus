using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages.Composers.Handshake;
public class HelloMessageComposer : AbstractMessageComposer {
    public override string Header => "HELLO";

    public override void Compose( IMessage message_structure ) {
        message_structure.WriteObject("date", DateTime.Now.ToShortDateString() );
    }
}
