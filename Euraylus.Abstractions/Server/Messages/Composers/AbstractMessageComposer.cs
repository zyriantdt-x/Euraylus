using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Server.Messages.Composers;
public abstract class AbstractMessageComposer {
    public abstract string Header { get; }

    public abstract void Compose( IMessage message_structure );
}
