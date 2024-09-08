using Euraylus.Chat.ChatUsers;
using Euraylus.Chat.Composers;
using Euraylus.Server.Messages;
using Euraylus.Storage;
using Euraylus.Storage.Sets;
using Euraylus.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Euraylus.Chat.Channels;
internal class ChannelService : IChannelService {
    private readonly EuraylusDbContext storage;
    private readonly IMessageSender message_sender;

    private readonly List<IChannel> channels;

    public ChannelService( EuraylusDbContext storage,
                           IMessageSender message_sender ) {
        this.storage = storage;
        this.message_sender = message_sender;

        this.channels = new();
        this.LoadChannels();
    }

    private IChannel CreateChannel( IChannelDataSet set ) 
        => new Channel() { 
                Uuid = set.Uuid, 
                Name = set.Name 
        };

    private void LoadChannels()
        => this.storage.ChannelDataSet.ToList().ForEach(set => {
            IChannel channel = this.CreateChannel( set );
            this.RegisterChannel( channel );
        } );

    private void RegisterChannel( IChannel channel )
        => this.channels.Add( channel );

    public IChannel? GetChannelByUuid( string uuid )
        => this.channels.Where( channel => channel.Uuid == uuid ).FirstOrDefault();

    public void JoinChannel( string channel_uuid, IUser user ) {
        IChannel? channel = this.GetChannelByUuid( channel_uuid );
        if( channel == null )
            return;

        this.JoinChannel( channel, user );
    }

    public void SendAvailableChannels( IUser user ) {
        List<IChannel> channels_to_send = this.channels; // todo: change this with permissions

        ChannelListMessageComposer composer = new() { Channels = channels_to_send };

        this.message_sender.SendMessage( user.Session!, composer );
    }

    public void JoinChannel( IChannel channel, IUser user ) {
        if( user.ChatUser != null )
            this.LeaveChannel( user );

        IChatUser chat_user = new ChatUser() {
            Uuid = Guid.NewGuid().ToString(),
            Channel = channel,
            User = user,
            PrivilegeLevel = user.Rank // change this
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
            this.message_sender.SendMessage(chat_user_1.User!.Session!, user_list_updated_composer );
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
