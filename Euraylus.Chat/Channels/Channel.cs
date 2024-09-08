using Euraylus.Chat.ChatUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels;
internal class Channel : IChannel {
    public required string Uuid { get; init; }
    public required string Name { get; set; }

    private readonly List<IChatUser> chat_users;

    public Channel() {
        this.chat_users = new();
    }

    public void AddChatUser( IChatUser chat_user )
        => this.chat_users.Add( chat_user );

    public void RemoveChatUser( IChatUser chat_user )
        => this.chat_users.Remove( chat_user );

    public ICollection<IChatUser> ChatUsers
        => this.chat_users;
}
