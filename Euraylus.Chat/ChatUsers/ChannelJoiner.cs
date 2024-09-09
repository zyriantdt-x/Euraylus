using Euraylus.Chat.Channels.Privileges;
using Euraylus.Chat.Channels;
using Euraylus.Chat.Composers;
using Euraylus.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euraylus.Server.Messages;

namespace Euraylus.Chat.ChatUsers;
public class ChannelJoiner : IChannelJoiner {
    private readonly IChannelService channel_service;
    private readonly IChannelPrivilegeService channel_privilege_service;
    private readonly IMessageSender message_sender;

    public ChannelJoiner( IChannelService channel_service,
                          IChannelPrivilegeService channel_privilege_service,
                          IMessageSender message_sender ) {
        this.channel_service = channel_service;
        this.channel_privilege_service = channel_privilege_service;
        this.message_sender = message_sender;
    }

    public void SendAvailableChannels( IUser user ) {
        List<IChannel> channels_to_send = this.channel_privilege_service.GetChannelPrivilegesByUser( user ).Select( channel => channel.Channel ).ToList();

        ChannelListMessageComposer composer = new() { Channels = channels_to_send };

        this.message_sender.SendMessage( user.Session!, composer );
    }

    public void JoinChannel( string channel_uuid, IUser user ) {
        IChannel? channel = this.channel_service.GetChannelByUuid( channel_uuid );
        if( channel == null )
            return;

        this.JoinChannel( channel, user );
    }

    public void JoinChannel( IChannel channel, IUser user ) {
        if( user.ChatUser != null )
            this.LeaveChannel( user );

        IChannelPrivilege? privileges = this.channel_privilege_service.GetChannelPrivilege( channel, user );
        if( privileges == null )
            return;

        IChatUser chat_user = new ChatUser() {
            Uuid = Guid.NewGuid().ToString(),
            Channel = channel,
            User = user,
            PrivilegeLevel = privileges.PrivilegeLevel
        };

        user.ChatUser = chat_user;
        channel.AddChatUser( chat_user );

        ChannelJoinedMessageComposer joined_composer = new() {
            Channel = channel,
            ChatUser = chat_user
        };

        ChannelUserListMessageComposer user_list_updated_composer = new() {
            ChatUsers = channel.ChatUsers.ToList()
        };

        this.message_sender.SendMessage( user.Session!, joined_composer );

        foreach( IChatUser chat_user_1 in channel.ChatUsers )
            this.message_sender.SendMessage( chat_user_1.User!.Session!, user_list_updated_composer );
    }

    public void LeaveChannel( IUser user ) {
        if( user.ChatUser == null )
            return;

        IChannel leaving_channel = user.ChatUser.Channel;

        user.ChatUser.Channel.RemoveChatUser( user.ChatUser );
        user.ChatUser = null;

        ChannelLeftComposer left_composer = new();

        ChannelUserListMessageComposer user_list_updated_composer = new() {
            ChatUsers = leaving_channel.ChatUsers.ToList()
        };

        this.message_sender.SendMessage( user.Session!, left_composer );

        foreach( IChatUser chat_user_1 in leaving_channel.ChatUsers )
            this.message_sender.SendMessage( chat_user_1.User!.Session!, user_list_updated_composer );
    }
}
