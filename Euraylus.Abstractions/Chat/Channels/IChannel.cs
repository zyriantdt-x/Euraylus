using Euraylus.Chat.ChatUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels;
public interface IChannel {
    string Uuid { get; init; }
    string Name { get; set; }

    void AddChatUser( IChatUser user );
    void RemoveChatUser( IChatUser user );

    ICollection<IChatUser> ChatUsers { get; }
}
